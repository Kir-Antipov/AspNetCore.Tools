using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a hosted service that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class HostedServiceAttribute : Attribute, IServiceAttribute
    {
        ServiceLifetime IServiceAttribute.Lifetime => ServiceLifetime.Singleton;

        Type? IServiceAttribute.ServiceType => typeof(IHostedService);

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
