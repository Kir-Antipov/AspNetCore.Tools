using AspNetCore.Tools.Helpers;
using AspNetCore.Tools.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ViewModels.Internal
{
    internal class ViewModelBuilderWrapper
    {
        private static readonly ModuleBuilder ModuleBuilder;

        static ViewModelBuilderWrapper()
        {
            AssemblyName name = new AssemblyName("<dynamic>AspNetCore.Tools.ViewModels");
            ModuleBuilder = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run).DefineDynamicModule(name.Name!);
        }

        private static MethodInfo? GetBuildMethod(Type modelBuilder) => modelBuilder.GetMethods().FirstOrDefault(x => !x.IsStatic && (x.Name == "Build" || x.Name == "BuildAsync" || x.Name == "TryBuild" || x.Name == "TryBuildAsync"));

        private static Type? GetViewModelType(Type modelBuilder)
        {
            MethodInfo? build = GetBuildMethod(modelBuilder)!;
            return GetModelBuilderStrategy(build) switch
            {
                ModelBuilderStrategy.Build => build.GetParameters()[^1].ParameterType,
                ModelBuilderStrategy.CreateAndBuild => build.ReturnType,
                ModelBuilderStrategy.TryBuild => build.GetParameters().Select(x => x.ParameterType).FirstOrDefault(x => x.IsByRef)?.GetElementType(),
                ModelBuilderStrategy.CreateAndTryBuild => build.GetParameters().Select(x => x.ParameterType).FirstOrDefault(x => x.IsByRef)?.GetElementType(),
                ModelBuilderStrategy.BuildAsync => build.GetParameters()[^1].ParameterType,
                ModelBuilderStrategy.CreateAndBuildAsync => build.ReturnType.GenericTypeArguments[0],
                ModelBuilderStrategy.TryBuildAsync => build.GetParameters()[^1].ParameterType,
                ModelBuilderStrategy.CreateAndTryBuildAsync => build.ReturnType.GenericTypeArguments[0].GenericTypeArguments[1],
                _ => null,
            };
        }

        private static ModelBuilderStrategy GetModelBuilderStrategy(MethodInfo? build)
        {
            if (build is null)
                return ModelBuilderStrategy.None;

            ParameterInfo[] parameters = build.GetParameters();
            Type returnType = build.ReturnType;
            if (typeof(Task).IsAssignableFrom(returnType))
            {
                if (returnType.IsGenericType)
                {
                    returnType = returnType.GetGenericArguments()[0];
                    if (returnType == typeof(bool))
                        return ModelBuilderStrategy.TryBuildAsync;

                    if (!string.IsNullOrEmpty(returnType.FullName) && returnType.FullName.StartsWith("System.ValueTuple`2"))
                        return returnType.IsGenericType && returnType.GenericTypeArguments[0] == typeof(bool) ? ModelBuilderStrategy.CreateAndTryBuildAsync : ModelBuilderStrategy.None;

                    return ModelBuilderStrategy.CreateAndBuildAsync;
                }
                else
                {
                    return parameters.Length != 0 ? ModelBuilderStrategy.BuildAsync : ModelBuilderStrategy.None;
                }
            }
            else
            {
                if (returnType == typeof(void))
                    return parameters.Length != 0 ? ModelBuilderStrategy.Build : ModelBuilderStrategy.None;

                if (returnType == typeof(bool))
                    return build.GetParameters().Any(x => x.IsOut) ? ModelBuilderStrategy.CreateAndTryBuild : ModelBuilderStrategy.TryBuild;

                return ModelBuilderStrategy.CreateAndBuild;
            }
        }

        private static Type? FindModelBuilderFor(Type modelType) => ReflectionHelper.GetMarkedTypes<ViewModelBuilderAttribute>()
                .FirstOrDefault(data => (data.Attribute.ViewModelType ?? GetViewModelType(data.Type)) is { } buildType && buildType.IsAssignableFrom(modelType)).Type;

        protected static TViewModelBuilderWrapper Create<TViewModelBuilderWrapper>() where TViewModelBuilderWrapper : ViewModelBuilderWrapper
        {
            Type wrapperType = typeof(TViewModelBuilderWrapper);
            Type baseModelType = wrapperType.GenericTypeArguments[0];
            Type? modelType = baseModelType.FindImplementation();
            if (modelType is null)
                throw new TypeLoadException($"Unable to instantiate {baseModelType.FullName}.");
            
            Type? modelBuilderType = FindModelBuilderFor(modelType);
            if (modelBuilderType is null)
                throw new TypeLoadException($"ViewModelBuilder for {baseModelType.FullName} not found.");

            return (TViewModelBuilderWrapper)Activator.CreateInstance(Create(wrapperType, modelBuilderType, baseModelType, modelType))!;
        }

        private static Type Create(Type wrapperType, Type modelBuilderType, Type baseModelType, Type modelType)
        {
            TypeBuilder typeBuilder = ModuleBuilder.DefineType($"{wrapperType.FullName}-{Guid.NewGuid()}{DateTime.Now.Ticks}", TypeAttributes.Public | TypeAttributes.Class, wrapperType);
            MethodInfo userBuildMethod = GetBuildMethod(modelBuilderType)!;
            ModelBuilderStrategy strategy = GetModelBuilderStrategy(userBuildMethod);
            OverrideMethod("TryGetViewModel" + (strategy.HasFlag(ModelBuilderStrategy.Async) ? "Async" : string.Empty), typeBuilder, modelBuilderType, baseModelType, modelType, userBuildMethod, strategy);
            return typeBuilder.CreateType()!;
        }

        private static void OverrideMethod(string name, TypeBuilder typeBuilder, Type viewModelBuilder, Type baseModelType, Type modelType, MethodInfo buildMethod, ModelBuilderStrategy strategy)
        {
            MethodInfo baseMethod = typeBuilder.BaseType!.GetMethod(name)!;
            Type[] parameters = Array.ConvertAll(baseMethod.GetParameters(), x => x.ParameterType);
            MethodBuilder method = typeBuilder.DefineMethod(name, MethodAttributes.Public | MethodAttributes.Virtual, baseMethod.ReturnType, parameters);
            ILGenerator il = method.GetILGenerator();
            PrepareOutput(il, parameters.Length, strategy);
            ImplementExecution(il, parameters, viewModelBuilder, modelType, buildMethod, out LocalBuilder? model);
            RedirectOutput(il, parameters.Length, baseModelType, modelType, model, strategy);
            typeBuilder.DefineMethodOverride(method, baseMethod);
        }

        private static void ImplementExecution(ILGenerator il, Type[] parameters, Type viewModelBuilder, Type modelType, MethodInfo buildMethod, out LocalBuilder? model)
        {
            model = null;
            LocalBuilder serviceProvider = EmitStoreServiceProvider(il);
            EmitCreateInstance(il, GetConstructor(viewModelBuilder), serviceProvider);
            int parameterIndex = 1;
            foreach (ParameterInfo parameter in buildMethod.GetParameters())
            {
                Type parameterType = parameter.ParameterType;
                if (parameterType.IsByRef)
                    parameterType = parameterType.GetElementType()!;

                if (typeof(ControllerBase).IsAssignableFrom(parameterType))
                {
                    il.Emit(OpCodes.Ldarg_1);
                }
                else if (parameterType.IsAssignableFrom(modelType))
                {
                    model = il.DeclareLocal(modelType);
                    if (!parameter.IsOut)
                    {
                        EmitCreateInstance(il, GetConstructor(modelType), serviceProvider);
                        if (!parameter.ParameterType.IsByRef)
                            il.Emit(OpCodes.Dup);
                        il.Emit(OpCodes.Stloc, model);
                    }
                    if (parameter.ParameterType.IsByRef)
                        il.Emit(OpCodes.Ldloca, model);
                }
                else if (parameterType == parameters[parameterIndex])
                {
                    il.Emit(OpCodes.Ldarg, ++parameterIndex);
                }
                else
                {
                    EmitGetService(il, parameterType, serviceProvider);
                }
            }
            il.Emit(buildMethod.IsVirtual ? OpCodes.Callvirt : OpCodes.Call, buildMethod);
        }

        private static void RedirectOutput(ILGenerator il, int parametersCount, Type baseModelType, Type modelType, LocalBuilder? model, ModelBuilderStrategy strategy)
        {
            switch (strategy)
            {
                case ModelBuilderStrategy.Build:
                    il.Emit(OpCodes.Ldarg, parametersCount);
                    il.Emit(OpCodes.Ldloc, model!);
                    if (modelType.IsValueType)
                        il.Emit(OpCodes.Stobj, modelType);
                    else
                        il.Emit(OpCodes.Stind_Ref);
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case ModelBuilderStrategy.CreateAndBuild:
                    if (modelType.IsValueType)
                        il.Emit(OpCodes.Stobj, modelType);
                    else
                        il.Emit(OpCodes.Stind_Ref);
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case ModelBuilderStrategy.TryBuild:
                case ModelBuilderStrategy.CreateAndTryBuild:
                    il.Emit(OpCodes.Ldarg, parametersCount);
                    il.Emit(OpCodes.Ldloc, model!);
                    if (modelType.IsValueType)
                        il.Emit(OpCodes.Stobj, modelType);
                    else
                        il.Emit(OpCodes.Stind_Ref);
                    break;
                case ModelBuilderStrategy.CreateAndBuildAsync:
                    il.Emit(OpCodes.Call, typeof(ViewModelBuilderWrapper).GetMethod(nameof(ViewModelBuilderWrapper.ConvertCreateAndBuildTask), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(baseModelType));
                    break;
                case ModelBuilderStrategy.BuildAsync:
                    il.Emit(OpCodes.Ldloc, model!);
                    il.Emit(OpCodes.Call, typeof(ViewModelBuilderWrapper).GetMethod(nameof(ViewModelBuilderWrapper.ConvertBuildTask), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(baseModelType));
                    break;
                case ModelBuilderStrategy.TryBuildAsync:
                    il.Emit(OpCodes.Ldloc, model!);
                    il.Emit(OpCodes.Call, typeof(ViewModelBuilderWrapper).GetMethod(nameof(ViewModelBuilderWrapper.ConvertTryBuildTask), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(baseModelType));
                    break;
                default:
                    break;
            }
            il.Emit(OpCodes.Ret);
        }

        private static void PrepareOutput(ILGenerator il, int parametersCount, ModelBuilderStrategy strategy)
        {
            if (strategy == ModelBuilderStrategy.CreateAndBuild)
                il.Emit(OpCodes.Ldarg, parametersCount);
        }

        private static ConstructorInfo GetConstructor(Type builder)
        {
            ConstructorInfo[] constructors = builder.GetConstructors();
            if (constructors.Length == 1)
            {
                return constructors[0];
            }
            else
            {
                return constructors
                    .FirstOrDefault(x => x.GetCustomAttribute<ActivatorUtilitiesConstructorAttribute>() is { }) ??
                    throw new TypeLoadException($"{builder.FullName} has more than one public constructor.");
            }
        }

        private static void EmitCreateInstance(ILGenerator il, ConstructorInfo constructor, LocalBuilder serviceProvider)
        {
            foreach (Type parameterType in constructor.GetParameters().Select(x => x.ParameterType))
            {
                if (typeof(ControllerBase).IsAssignableFrom(parameterType))
                    il.Emit(OpCodes.Ldarg_1);
                else
                    EmitGetService(il, parameterType, serviceProvider);
            }

            il.Emit(OpCodes.Newobj, constructor);

            foreach (MethodInfo setter in constructor.DeclaringType!.GetProperties().Where(x => x.GetCustomAttribute<InjectServiceAttribute>() is { } && x.SetMethod is { }).Select(x => x.SetMethod!))
            {
                il.Emit(OpCodes.Dup);
                EmitGetService(il, setter.GetParameters()[0].ParameterType, serviceProvider);
                il.Emit(OpCodes.Callvirt, setter);
            }
        }

        private static void EmitGetService(ILGenerator il, Type serviceType, LocalBuilder serviceProvider)
        {
            il.Emit(OpCodes.Ldloc, serviceProvider);
            il.Emit(OpCodes.Ldtoken, serviceType);
            il.Emit(OpCodes.Call, typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle))!);
            il.Emit(OpCodes.Call, typeof(ServiceProviderServiceExtensions).GetMethod(nameof(ServiceProviderServiceExtensions.GetRequiredService), new[] { typeof(IServiceProvider), typeof(Type) })!);
            if (serviceType.IsValueType)
                il.Emit(OpCodes.Unbox, serviceType);
        }

        private static LocalBuilder EmitStoreServiceProvider(ILGenerator il)
        {
            LocalBuilder services = il.DeclareLocal(typeof(IServiceProvider));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, typeof(ControllerBase).GetProperty(nameof(ControllerBase.HttpContext))!.GetMethod!);
            il.Emit(OpCodes.Callvirt, typeof(HttpContext).GetProperty(nameof(HttpContext.RequestServices))!.GetMethod!);
            il.Emit(OpCodes.Stloc, services);
            return services;
        }

        protected static async Task<(bool, TViewModel)> ConvertCreateAndBuildTask<TViewModel>(Task<TViewModel> task) => (true, await task);

        protected static async Task<(bool, TViewModel)> ConvertBuildTask<TViewModel>(Task task, TViewModel model)
        {
            await task;
            return (true, model);
        }

        protected static async Task<(bool, TViewModel)> ConvertTryBuildTask<TViewModel>(Task<bool> task, TViewModel model) => (await task, model);
    }
}
