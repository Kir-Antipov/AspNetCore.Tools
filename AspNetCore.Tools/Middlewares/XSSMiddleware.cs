using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore.Tools.Middlewares
{
    /// <summary>
    /// Middleware which activates the built-in browser protection against xss attacks.
    /// </summary>
    public class XSSMiddleware : MiddlewareBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XSSMiddleware"/> class.
        /// </summary>
        /// <param name="next">Delegate that repersents next middleware action.</param>
        public XSSMiddleware(RequestDelegate next) : base(next) { }

        /// <inheritdoc cref="MiddlewareBase.Invoke(HttpContext)"/>
        public override Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("x-xss-protection", "1");
            return Next(context);
        }
    }
}
