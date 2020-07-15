using AspNetCore.Tools.Helpers;
using AspNetCore.Tools.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Extension methods for adding middlewares to the application's request pipeline.
    /// </summary>
    public static partial class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="XSSMiddleware"/> to the application's request pipeline to prevent xss attacks.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseXssProtection(this IApplicationBuilder app) => app.UseMiddleware<XSSMiddleware>();

        /// <inheritdoc cref="UseCsp(IApplicationBuilder, string?)"/>
        public static IApplicationBuilder UseCsp(this IApplicationBuilder app) => app.UseCsp(null);

        /// <summary>
        /// Adds the <see cref="CSPMiddleware"/> to the application's request pipeline to configure the Content Security Policy.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="policy">Content Security Policy value.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseCsp(this IApplicationBuilder app, string? policy) => app.UseMiddleware<CSPMiddleware>(policy ?? string.Empty);

        /// <summary>
        /// Adds all middlewares marked with <see cref="MiddlewareAttribute"/> to the application's request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="skipOnFailure">Indicates whether the method should be aborted if an exception occurs.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseMarkedMiddlewares(this IApplicationBuilder app, bool skipOnFailure = false)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));

            foreach (var (middleware, attr) in ReflectionHelper.GetMarkedTypes<MiddlewareAttribute>().OrderByDescending(x => x.Attribute.Priority))
                try
                {
                    app.UseMiddleware(middleware, args: attr.Arguments);
                }
                catch
                {
                    if (!skipOnFailure)
                        throw;
                }

            return app;
        }
    }
}
