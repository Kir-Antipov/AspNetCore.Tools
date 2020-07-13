using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a singleton service that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class SingletonServiceAttribute : Attribute, IServiceAttribute
    {
        ServiceLifetime IServiceAttribute.Lifetime => ServiceLifetime.Singleton;

        /// <inheritdoc cref="ServiceAttribute.ServiceType"/>
        public Type? ServiceType { get; set; }

        /// <inheritdoc cref="ServiceAttribute.Factory"/>
        public Type? Factory { get; set; }

        /// <summary>
        /// Indicates whether to implement a factory for the service automatically.
        /// </summary>
        /// <remarks>
        /// Default value is <see langword="true"/>.
        /// </remarks>
        public bool UseAutoImplementedFactory { get; set; } = true;
    }
}
