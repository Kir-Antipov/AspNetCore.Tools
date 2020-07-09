using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore.Tools.Middlewares
{
    /// <summary>
    /// Base class for simple middlewares.
    /// </summary>
    public abstract class MiddlewareBase
    {
        /// <summary>
        /// Invokes next middleware.
        /// </summary>
        protected readonly RequestDelegate Next;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiddlewareBase"/> class.
        /// </summary>
        /// <param name="next">Delegate that repersents next middleware action.</param>
        public MiddlewareBase(RequestDelegate next) => Next = next;

        /// <summary>
        /// Invokes middleware request processing.
        /// </summary>
        /// <param name="context">Encapsulates all HTTP-specific information about current HTTP request.</param>
        /// <returns>A <see cref="Task"/> that represents the completion of request processing.</returns>
        public abstract Task Invoke(HttpContext context);
    }
}
