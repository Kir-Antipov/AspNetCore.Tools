using AspNetCore.Tools.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Tools.Services
{
    internal class AutoServiceFactory<TService> : IServiceFactory
    {
        public static IServiceScope? Scope { get; private set; }

        public object GetService(IServiceProvider services)
        {
            ConstructorInfo constructor = GetConstructor(GetImplementation(typeof(TService)));
            ParameterInfo[] parameters = constructor.GetParameters();
            object?[] args = new object?[parameters.Length];

            Scope = services.CreateScope();
            for (int i = 0; i < args.Length; ++i)
                args[i] = Scope.ServiceProvider.GetRequiredService(parameters[i].ParameterType);

            return constructor.Invoke(args);
        }

        private static Type GetImplementation(Type serviceType)
        {
            Type? implementationType = serviceType.FindImplementation();
            if (implementationType is null)
                throw new TypeLoadException($"{serviceType.FullName} has no implementation.");
            return implementationType;
        }

        private static ConstructorInfo GetConstructor(Type serviceType)
        {
            ConstructorInfo[] constructors = serviceType.GetConstructors();
            if (constructors.Length == 1)
            {
                return constructors[0];
            }
            else
            {
                return constructors
                    .FirstOrDefault(x => x.GetCustomAttribute<ActivatorUtilitiesConstructorAttribute>() is { }) ??
                    throw new TypeLoadException($"{serviceType.FullName} has more than one public constructor.");
            }
        }
    }
}
