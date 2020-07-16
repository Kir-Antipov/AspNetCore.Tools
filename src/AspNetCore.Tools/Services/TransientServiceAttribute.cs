using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a transient service that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class TransientServiceAttribute : Attribute, IServiceAttribute
    {
        ServiceLifetime IServiceAttribute.Lifetime => ServiceLifetime.Transient;

        bool IServiceAttribute.UseAutoImplementedFactory => false;

        /// <inheritdoc cref="ServiceAttribute.ServiceType"/>
        public Type? ServiceType { get; set; }

        /// <inheritdoc cref="ServiceAttribute.Factory"/>
        public Type? Factory { get; set; }
    }
}
