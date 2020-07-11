using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Base class for providers of model binders.
    /// </summary>
    public abstract class ModelBinderProviderBase : IModelBinderProvider
    {
        /// <inheritdoc cref="IModelBinderProvider.GetBinder(ModelBinderProviderContext)"/>
        public abstract IModelBinder? GetBinder(ModelBinderProviderContext context);
    }
}
