using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a service that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceAttribute : Attribute, IServiceAttribute
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
        /// If no value was provided, the type to which this attribute was applied is used.
        /// </remarks>
        public Type? ServiceType { get; set; }

        /// <summary>
        /// <see cref="IServiceFactory"/> used for creating service instances.
        /// </summary>
        /// <remarks>
        /// If no value was provided, default DI factory is used.
        /// </remarks>
        public Type? Factory { get; set; }

        /// <summary>
        /// Indicates whether to implement a factory for the service automatically.
        /// </summary>
        /// <remarks>
        /// Default value is <see langword="false"/>.
        /// <para/>
        /// It is not recommended to use this value for any services except <see cref="ServiceLifetime.Singleton"/>'s!
        /// </remarks>
        public bool UseAutoImplementedFactory { get; set; }
    }
}
