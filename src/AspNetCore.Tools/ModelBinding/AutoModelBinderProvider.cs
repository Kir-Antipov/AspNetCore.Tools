using AspNetCore.Tools.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace AspNetCore.Tools.ModelBinding
{
    internal static class AutoModelBinderProvider
    {
        private static readonly ModuleBuilder ModuleBuilder;

        static AutoModelBinderProvider()
        {
            AssemblyName name = new AssemblyName("<dynamic>AspNetCore.Tools.ModelBinding");
            ModuleBuilder = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run).DefineDynamicModule(name.Name!);
        }

        public static Type Create(Type modelBinderType, params Type[] acceptedModelTypes)
        {
            AssertIsValidModelBinderType(modelBinderType);
            acceptedModelTypes ??= Type.EmptyTypes;

            Type baseType = modelBinderType.GetConstructor(Type.EmptyTypes) is { } ? typeof(SingletonModelBinderProviderBase<>) : typeof(DIModelBinderProviderBase<>);
            baseType = baseType.MakeGenericType(modelBinderType);
            TypeBuilder typeBuilder = ModuleBuilder.DefineType($"{modelBinderType.FullName}Provider-{Guid.NewGuid()}{DateTime.Now.Ticks}", TypeAttributes.Public | TypeAttributes.Class, baseType);
            DefineIsSuitable(baseType, typeBuilder, acceptedModelTypes);

            return typeBuilder.CreateType()!;
        }

        private static void AssertIsValidModelBinderType(Type modelBinderType)
        {
            _ = modelBinderType ?? throw new ArgumentNullException(nameof(modelBinderType));

            if (!modelBinderType.CouldBeInstance())
                throw new ArgumentException($"Unable to create instance of {modelBinderType.FullName}.", nameof(modelBinderType));
        }

        private static void DefineIsSuitable(Type baseType, TypeBuilder typeBuilder, Type[] acceptedModelTypes)
        {
            MethodInfo baseIsSuitable = baseType.GetMethod("IsSuitable")!;
            MethodBuilder isSuitable = typeBuilder.DefineMethod(baseIsSuitable.Name, MethodAttributes.Public | MethodAttributes.Virtual, typeof(bool), new[] { typeof(ModelBinderProviderContext) });
            ImplementIsSuitable(isSuitable.GetILGenerator(), acceptedModelTypes);
            typeBuilder.DefineMethodOverride(isSuitable, baseIsSuitable);
        }

        private static void ImplementIsSuitable(ILGenerator il, Type[] acceptedModelTypes)
        {
            if (acceptedModelTypes.Length == 0)
            {
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Ret);
            }
            else
            {
                Label successLabel = il.DefineLabel();
                LocalBuilder handle = il.DeclareLocal(typeof(RuntimeTypeHandle));

                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Callvirt, typeof(ModelBinderProviderContext).GetProperty(nameof(ModelBinderProviderContext.Metadata))!.GetMethod!);
                il.Emit(OpCodes.Call, typeof(ModelMetadata).GetProperty(nameof(ModelMetadata.ModelType))!.GetMethod!);
                il.Emit(OpCodes.Callvirt, typeof(Type).GetProperty(nameof(Type.TypeHandle))!.GetMethod!);
                il.Emit(OpCodes.Stloc, handle);
                il.Emit(OpCodes.Ldloca, handle);
                il.Emit(OpCodes.Call, typeof(RuntimeTypeHandle).GetProperty(nameof(RuntimeTypeHandle.Value))!.GetMethod!);
                
                for (int i = 0; i < acceptedModelTypes.Length; ++i)
                {
                    IntPtr pointer = acceptedModelTypes[i].TypeHandle.Value;

                    il.Emit(OpCodes.Dup);

                    if (IntPtr.Size == sizeof(int))
                        il.Emit(OpCodes.Ldc_I4, pointer.ToInt32());
                    else
                        il.Emit(OpCodes.Ldc_I8, pointer.ToInt64());
                    il.Emit(OpCodes.Beq, successLabel);
                }

                il.Emit(OpCodes.Pop);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Ret);

                il.MarkLabel(successLabel);

                il.Emit(OpCodes.Pop);
                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Ret);
            }
        }
    }
}
