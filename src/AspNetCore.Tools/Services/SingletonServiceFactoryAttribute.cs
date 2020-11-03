using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Marks class as a singleton service factory that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class SingletonServiceFactoryAttribute : Attribute, IServiceFactoryAttribute
    {
        ServiceLifetime IServiceFactoryAttribute.Lifetime => ServiceLifetime.Singleton;

        /// <inheritdoc cref="ServiceFactoryAttribute.ServiceType"/>
        public Type? ServiceType { get; set; }

        /// <inheritdoc cref="ServiceFactoryAttribute.Factory"/>
        public Type? Factory { get; set; }
    }
}
