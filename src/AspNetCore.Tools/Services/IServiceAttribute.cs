using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Basic interface for service attributes.
    /// </summary>
    public interface IServiceAttribute
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

        /// <summary>
        /// Indicates whether to implement a factory for the service automatically.
        /// </summary>
        bool UseAutoImplementedFactory { get; }
    }
}
