using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore.Tools.Middlewares
{
    /// <summary>
    /// Middleware to configure the Content Security Policy of your web application.
    /// </summary>
    public class CSPMiddleware : MiddlewareBase
    {
        /// <summary>
        /// Default Content Security Policy value.
        /// </summary>
        public const string DefaultPolicy = "default-src 'self'";

        /// <summary>
        /// Content Security Policy value.
        /// </summary>
        public string Policy { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSPMiddleware"/> class.
        /// </summary>
        /// <param name="next">Delegate that repersents next middleware action.</param>
        /// <param name="policy">Content Security Policy value.</param>
        public CSPMiddleware(RequestDelegate next, string? policy = null) : base(next) => Policy = string.IsNullOrEmpty(policy) ? DefaultPolicy : policy;

        /// <inheritdoc cref="MiddlewareBase.Invoke(HttpContext)"/>
        public override Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Content-Security-Policy", Policy);
            return Next(context);
        }
    }
}
