using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Base class for model binders.
    /// </summary>
    public abstract class ModelBinderBase : IModelBinder
    {
        /// <inheritdoc cref="IModelBinder.BindModelAsync(ModelBindingContext)"/>
        public virtual Task BindModelAsync(ModelBindingContext bindingContext)
        {
            BindModel(bindingContext);
            return Task.CompletedTask;
        }

        /// <returns></returns>
        /// <inheritdoc cref="IModelBinder.BindModelAsync(ModelBindingContext)"/>
        public virtual void BindModel(ModelBindingContext bindingContext) { }
    }
}
