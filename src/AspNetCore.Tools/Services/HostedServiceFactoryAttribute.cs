using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a hosted service factory that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class HostedServiceFactoryAttribute : Attribute, IServiceFactoryAttribute
    {
        ServiceLifetime IServiceFactoryAttribute.Lifetime => ServiceLifetime.Singleton;

        Type? IServiceFactoryAttribute.ServiceType => typeof(IHostedService);

        /// <inheritdoc cref="ServiceFactoryAttribute.Factory"/>
        public Type? Factory { get; set; }
    }
}
