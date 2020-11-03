using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a service factory that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceFactoryAttribute : Attribute, IServiceFactoryAttribute
    {
        /// <summary>
        /// The <see cref="ServiceLifetime"/> of the service.
        /// </summary>
        /// <remarks>
        /// Default value is <see cref="ServiceLifetime.Scoped"/>.
        /// </remarks>
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Scoped;

        /// <summary>
        /// The <see cref="Type"/> of the service.
        /// </summary>
        /// <remarks>
        /// The service type can be omitted if the factory implements
        /// the <see cref="IServiceFactory{TService}"/> interface.
        /// </remarks>
        public Type? ServiceType { get; set; }

        /// <summary>
        /// <see cref="IServiceFactory"/> used for creating service instances.
        /// </summary>
        /// <remarks>
        /// If no value was provided, the type to which this attribute was applied is used.
        /// </remarks>
        public Type? Factory { get; set; }
    }
}
