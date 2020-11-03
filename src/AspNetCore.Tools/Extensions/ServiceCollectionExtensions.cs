using AspNetCore.Tools.Helpers;
using AspNetCore.Tools.Services;
using AspNetCore.Tools.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Extension methods for adding services to an <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all services marked with <see cref="IServiceAttribute"/> and
        /// all factories marked with <see cref="IServiceFactoryAttribute"/>
        /// to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="skipOnFailure">Indicates whether the method should be aborted if an exception occurs.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddMarked(this IServiceCollection services, bool skipOnFailure = false)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            foreach (var (service, attr) in ReflectionHelper.GetMarkedTypes<IServiceAttribute>())
                try
                {
                    AddService(services, service, attr);
                }
                catch
                {
                    if (!skipOnFailure)
                        throw;
                }

            foreach (var (factory, attr) in ReflectionHelper.GetMarkedTypes<IServiceFactoryAttribute>())
                try
                {
                    AddServiceFactory(services, factory, attr);
                }
                catch
                {
                    if (!skipOnFailure)
                        throw;
                }

            return services;
        }

        /// <summary>
        /// Adds default implementation of the <see cref="IViewModelFactory"/> service
        /// to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddDefaultViewModelFactory(this IServiceCollection services) => services.AddSingleton((IViewModelFactory)new DefaultViewModelFactory());

        private static void AddService(IServiceCollection services, Type service, IServiceAttribute attribute)
        {
            if (attribute.Factory is { } || attribute.UseAutoImplementedFactory)
                AddServiceWithFactory(services, service, attribute);
            else
                AddServiceWithImplementation(services, service, attribute);
        }

        private static void AddServiceWithFactory(IServiceCollection services, Type service, IServiceAttribute attribute)
        {
            Type factoryType = attribute.Factory ?? typeof(AutoServiceFactory<>).MakeGenericType(service);
            if (!(CreateFactoryInstance(factoryType) is { } factory))
                throw new TypeLoadException($"{factoryType.FullName} must implement {typeof(IServiceFactory).FullName} and have parameterless constructor.");

            services.Add(new ServiceDescriptor(attribute.ServiceType ?? service, factory.GetService, attribute.Lifetime));
        }

        private static IServiceFactory? CreateFactoryInstance(Type factoryType)
        {
            Type? factoryImplementationType = factoryType.FindImplementation();
            if (factoryImplementationType is null)
                return default;

            if (!typeof(IServiceFactory).IsAssignableFrom(factoryImplementationType))
                return default;

            if (!(factoryImplementationType.GetConstructor(Type.EmptyTypes) is { } constructor))
                return default;

            return (IServiceFactory)constructor.Invoke(Array.Empty<object>());
        }

        private static void AddServiceWithImplementation(IServiceCollection services, Type service, IServiceAttribute attribute)
        {
            if (!(service.FindImplementation() is { } implementationType))
                throw new TypeLoadException($"{service.FullName} has no implementation.");

            services.Add(new ServiceDescriptor(attribute.ServiceType ?? service, implementationType, attribute.Lifetime));
        }

        private static void AddServiceFactory(IServiceCollection services, Type factory, IServiceFactoryAttribute attribute)
        {
            Type factoryImplementation = attribute.Factory ?? factory;
            if (!(CreateFactoryInstance(factoryImplementation) is { } factoryInstance))
                throw new TypeLoadException($"{factoryImplementation.FullName} must implement {typeof(IServiceFactory).FullName} and have parameterless constructor.");
            
            factoryImplementation = factoryInstance.GetType();

            Type? serviceType = attribute.ServiceType;
            serviceType ??= factoryImplementation
                .GetInterfaces()
                .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IServiceFactory<>))?
                .GetGenericArguments()[0];

            if (serviceType is null)
                throw new TypeLoadException($"The {nameof(IServiceFactoryAttribute.ServiceType)} property wasn't set for the {factoryImplementation.FullName}.");

            services.Add(new ServiceDescriptor(serviceType, factoryInstance.GetService, attribute.Lifetime));
        }
    }
}
