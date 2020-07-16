using AspNetCore.Tools.Helpers;
using AspNetCore.Tools.Services;
using AspNetCore.Tools.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Extension methods for adding services to an <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all services marked with <see cref="IServiceAttribute"/>
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
            if (!typeof(IServiceFactory).IsAssignableFrom(factoryType))
                return default;

            if (!(factoryType.GetConstructor(Type.EmptyTypes) is { } constructor))
                return default;

            return (IServiceFactory)constructor.Invoke(Array.Empty<object>());
        }

        private static void AddServiceWithImplementation(IServiceCollection services, Type service, IServiceAttribute attribute)
        {
            if (!(service.FindImplementation() is { } implementationType))
                throw new TypeLoadException($"{service.FullName} has no implementation.");

            services.Add(new ServiceDescriptor(attribute.ServiceType ?? service, implementationType, attribute.Lifetime));
        }
    }
}
