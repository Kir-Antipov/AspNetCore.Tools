using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a scoped service that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class ScopedServiceAttribute : Attribute, IServiceAttribute
    {
        ServiceLifetime IServiceAttribute.Lifetime => ServiceLifetime.Scoped;

        bool IServiceAttribute.UseAutoImplementedFactory => false;

        /// <inheritdoc cref="ServiceAttribute.ServiceType"/>
        public Type? ServiceType { get; set; }

        /// <inheritdoc cref="ServiceAttribute.Factory"/>
        public Type? Factory { get; set; }
    }
}
