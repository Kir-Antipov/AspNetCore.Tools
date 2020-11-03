using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Basic interface for service factory attributes.
    /// </summary>
    public interface IServiceFactoryAttribute
    {
        /// <summary>
        /// The <see cref="ServiceLifetime"/> of the service.
        /// </summary>
        ServiceLifetime Lifetime { get; }

        /// <summary>
        /// The <see cref="Type"/> of the service.
        /// </summary>
        Type? ServiceType { get; }

        /// <summary>
        /// A factory used for creating service instances.
        /// </summary>
        Type? Factory { get; }
    }
}
