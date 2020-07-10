using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace AspNetCore.Tools.Middlewares
{
    internal static class InlineMiddleware
    {
        private static readonly ModuleBuilder ModuleBuilder;

        static InlineMiddleware()
        {
            AssemblyName name = new AssemblyName("<dynamic>AspNetCore.Tools.Middlewares");
            ModuleBuilder = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run).DefineDynamicModule(name.Name!);
        }

        public static Type Create(Action action) => Create((next, context) =>
        {
            action();
            return next(context);
        });

        public static Type Create(Func<Task> action) => Create(async (next, context) =>
        {
            await action();
            await next(context);
        });

        public static Type Create(Action<HttpContext> action) => Create((next, context) =>
        {
            action(context);
            return next(context);
        });

        public static Type Create(Func<HttpContext, Task> action) => Create(async (next, context) =>
        {
            await action(context);
            await next(context);
        });

        public static Type Create(Func<RequestDelegate, HttpContext, Task> action) => Create((Delegate)action);

        public static Type Create(Delegate action)
        {
            AssertIsValidDelegate(action);

            TypeBuilder typeBuilder = ModuleBuilder.DefineType($"Middleware{DateTime.Now.ToBinary()}{Guid.NewGuid()}", TypeAttributes.Public | TypeAttributes.Class);
            FieldBuilder nextField = DefineNext(typeBuilder);
            FieldBuilder actionField = DefineAction(typeBuilder, action.GetType());
            DefineConstructor(typeBuilder, nextField);
            DefineInvoke(typeBuilder, nextField, actionField);

            Type t = typeBuilder.CreateType()!;
            t.GetField(actionField.Name, BindingFlags.NonPublic | BindingFlags.Static)!.SetValue(null, action);

            return t;
        }

        private static void AssertIsValidDelegate(Delegate action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            Type delegateType = action.GetType();
            if (delegateType.FullName is null || !delegateType.FullName.StartsWith("System.Func"))
                throw new ArgumentException("The delegate must be of type System.Func", nameof(action));

            Type[] generics = delegateType.GetGenericArguments();
            if (generics.Length < 3 || generics[0] != typeof(RequestDelegate) || generics[1] != typeof(HttpContext) || generics[^1] != typeof(Task))
                throw new ArgumentException($"The delegate must return an object of type {typeof(Task).FullName}, and its first two input parameters must be of type {typeof(RequestDelegate).FullName} and {typeof(HttpContext).FullName}.", nameof(action));
        }

        private static void DefineConstructor(TypeBuilder typeBuilder, FieldBuilder next)
        {
            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new[] { typeof(RequestDelegate) });
            ImplementConstructor(constructorBuilder.GetILGenerator(), next);
        }

        private static void ImplementConstructor(ILGenerator il, FieldBuilder next)
        {
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes)!);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, next);
            il.Emit(OpCodes.Ret);
        }

        private static void DefineInvoke(TypeBuilder typeBuilder, FieldBuilder next, FieldBuilder action)
        {
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Invoke", MethodAttributes.Public | MethodAttributes.Virtual, typeof(Task), action.FieldType.GetGenericArguments()[1..^1]);
            ImplementInvoke(methodBuilder.GetILGenerator(), next, action);
        }

        private static void ImplementInvoke(ILGenerator il, FieldBuilder next, FieldBuilder action)
        {
            il.Emit(OpCodes.Ldsfld, action);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, next);

            int parametersCount = action.FieldType.GetGenericArguments().Length - 2;
            for (int i = 1; i <= parametersCount; ++i)
                il.Emit(OpCodes.Ldarg, i);

            il.Emit(OpCodes.Callvirt, action.FieldType.GetMethod("Invoke")!);
            il.Emit(OpCodes.Ret);
        }

        private static FieldBuilder DefineNext(TypeBuilder typeBuilder) =>
            typeBuilder.DefineField("Next", typeof(RequestDelegate), FieldAttributes.Public);

        private static FieldBuilder DefineAction(TypeBuilder typeBuilder, Type actionType) =>
            typeBuilder.DefineField("Action", actionType, FieldAttributes.Private | FieldAttributes.Static);
    }
}
