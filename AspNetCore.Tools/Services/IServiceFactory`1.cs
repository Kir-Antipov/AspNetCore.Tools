using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Defines a factory for the <typeparamref name="TService"/>.
    /// </summary>
    /// <typeparam name="TService">Service type.</typeparam>
    public interface IServiceFactory<out TService> : IServiceFactory where TService : notnull
    {
        object IServiceFactory.GetService(IServiceProvider services) => GetService(services);

        /// <inheritdoc cref="IServiceFactory.GetService(IServiceProvider)"/>
        new TService GetService(IServiceProvider services);
    }
}
