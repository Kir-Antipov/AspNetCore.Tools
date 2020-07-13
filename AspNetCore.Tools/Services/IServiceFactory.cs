using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Defines a factory for some service.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Provides service.
        /// </summary>
        /// <param name="services">The <see cref="IServiceProvider"/> instance.</param>
        /// <returns>Service instance.</returns>
        object GetService(IServiceProvider services);
    }
}
