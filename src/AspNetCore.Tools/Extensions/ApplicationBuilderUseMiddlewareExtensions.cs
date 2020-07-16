using AspNetCore.Tools.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Extension methods for adding middlewares to the application's request pipeline.
    /// </summary>
    public static partial class ApplicationBuilderExtensions
    {
        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Action action) => app.UseMiddleware(InlineMiddleware.Create(action));
        
        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Func<Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));
        
        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Action<HttpContext> action) => app.UseMiddleware(InlineMiddleware.Create(action));
        
        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Func<HttpContext, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));
        
        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <inheritdoc cref="UseMiddleware{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}(IApplicationBuilder, Func{RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task})"/>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));

        /// <summary>
        /// Adds a middleware to the application's request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="action">The middleware action.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        /// <typeparam name="T1">The 1st parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T2">The 2nd parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T3">The 3rd parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T4">The 4th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T5">The 5th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T6">The 6th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T7">The 7th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T8">The 8th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T9">The 9th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T10">The 10th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T11">The 11th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T12">The 12th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T13">The 13th parameter of the method to be provided by DI.</typeparam>
        /// <typeparam name="T14">The 14th parameter of the method to be provided by DI.</typeparam>
        public static IApplicationBuilder UseMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IApplicationBuilder app, Func<RequestDelegate, HttpContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task> action) => app.UseMiddleware(InlineMiddleware.Create(action));
    }
}
