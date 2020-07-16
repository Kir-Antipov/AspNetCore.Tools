using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AspNetCore.Tools.ActionFilters
{
    /// <summary>
    /// Base class for filters that surround execution of the action.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class ActionFilterBase : Attribute, IActionFilter
    {
        /// <inheritdoc cref="IActionFilter.OnActionExecuting(ActionExecutingContext)"/>
        public virtual void OnActionExecuting(ActionExecutingContext context) { }

        /// <inheritdoc cref="IActionFilter.OnActionExecuted(ActionExecutedContext)"/>
        public virtual void OnActionExecuted(ActionExecutedContext context) { }
    }
}
