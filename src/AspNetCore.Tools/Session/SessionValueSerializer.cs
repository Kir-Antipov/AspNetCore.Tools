using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using SessionExtensions = AspNetCore.Tools.Extensions.SessionExtensions;
using OriginalSessionExtensions = Microsoft.AspNetCore.Http.SessionExtensions;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Tools.Session
{
    /// <summary>
    /// Base class for entity serializers.
    /// </summary>
    public abstract class SessionValueSerializer
    {
        private static readonly ModuleBuilder ModuleBuilder;

        static SessionValueSerializer()
        {
            AssemblyName name = new AssemblyName("<dynamic>AspNetCore.Tools.Session");
            ModuleBuilder = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run).DefineDynamicModule(name.Name!);
        }

        /// <summary>
        /// Creates instance of the <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="SessionValueSerializer"/>'s successor.</typeparam>
        /// <typeparam name="U">Entity type.</typeparam>
        /// <returns>Instance of the <typeparamref name="T"/>.</returns>
        protected static T Create<T, U>() where T : SessionValueSerializer<U>, new()
        {
            if (typeof(U) == typeof(int))
                return Override<T>( typeof(OriginalSessionExtensions).GetMethod(nameof(OriginalSessionExtensions.SetInt32))!, 
                                    typeof(SessionExtensions).GetMethod(nameof(SessionExtensions.TryGetValue), GetTryGetValueTypes<U>())!);

            if (typeof(U) == typeof(long))
                return Override<T>( typeof(SessionExtensions).GetMethod(nameof(SessionExtensions.SetInt64))!, 
                                    typeof(SessionExtensions).GetMethod(nameof(SessionExtensions.TryGetValue), GetTryGetValueTypes<U>())!);

            if (typeof(U) == typeof(bool))
                return Override<T>( typeof(SessionExtensions).GetMethod(nameof(SessionExtensions.SetBoolean))!, 
                                    typeof(SessionExtensions).GetMethod(nameof(SessionExtensions.TryGetValue), GetTryGetValueTypes<U>())!);

            if (typeof(U) == typeof(string))
                return Override<T>( typeof(OriginalSessionExtensions).GetMethod(nameof(OriginalSessionExtensions.SetString))!, 
                                    typeof(SessionExtensions).GetMethod(nameof(SessionExtensions.TryGetValue), GetTryGetValueTypes<U>())!);

            return new T();
        }

        private static Type[] GetTryGetValueTypes<U>() => new[] { typeof(ISession), typeof(string), typeof(U).MakeByRefType() };

        [return: NotNull]
        private static T Override<T>(MethodInfo setMethod, MethodInfo tryGetValueMethod) => (T)Activator.CreateInstance(Override(typeof(T), setMethod, tryGetValueMethod))!;

        private static Type Override(Type baseType, MethodInfo setMethod, MethodInfo tryGetValueMethod)
        {
            TypeBuilder typeBuilder = ModuleBuilder.DefineType($"{baseType.Name}-{Guid.NewGuid()}{DateTime.Now.Ticks}", TypeAttributes.Public | TypeAttributes.Class, baseType);
            OverrideMethod(typeBuilder, "Set", setMethod);
            OverrideMethod(typeBuilder, "TryGetValue", tryGetValueMethod);
            return typeBuilder.CreateType()!;
        }

        private static void OverrideMethod(TypeBuilder typeBuilder, string methodName, MethodInfo redirectTo)
        {
            MethodBuilder newMethod = typeBuilder.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.Virtual, redirectTo.ReturnType, Array.ConvertAll(redirectTo.GetParameters(), x => x.ParameterType));
            RedirectOutput(newMethod.GetILGenerator(), redirectTo);
            typeBuilder.DefineMethodOverride(newMethod, typeBuilder.BaseType!.GetMethod(newMethod.Name)!);
        }

        private static void RedirectOutput(ILGenerator il, MethodInfo target)
        {
            int parameters = target.GetParameters().Length;
            for (int i = 1; i <= parameters; ++i)
                il.Emit(OpCodes.Ldarg, i);
            il.Emit(OpCodes.Call, target);
            il.Emit(OpCodes.Ret);
        }
    }
}
