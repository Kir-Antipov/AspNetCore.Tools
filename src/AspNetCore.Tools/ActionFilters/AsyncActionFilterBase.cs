using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ActionFilters
{
    /// <summary>
    /// Base class for filters that asynchronously surround execution of the action,
    /// after model binding is complete.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class AsyncActionFilterBase : Attribute, IAsyncActionFilter
    {
        /// <inheritdoc cref="IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext, ActionExecutionDelegate)"/>
        public abstract Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);
    }
}
