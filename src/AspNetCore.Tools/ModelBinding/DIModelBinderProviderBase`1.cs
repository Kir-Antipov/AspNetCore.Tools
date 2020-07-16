using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Base class for providers of model binders that require services from DI.
    /// </summary>
    /// <typeparam name="TModelBinder">Model binder type.</typeparam>
    public abstract class DIModelBinderProviderBase<TModelBinder> : ModelBinderProviderBase where TModelBinder : IModelBinder
    {
        /// <summary>
        /// This method determines whether the model binder is suitable for the current context or not.
        /// </summary>
        /// <param name="context">The <see cref="ModelBinderProviderContext"/>.</param>
        /// <returns><see langword="true"/> if model binder is suitable; <see langword="false"/> otherwise.</returns>
        public abstract bool IsSuitable(ModelBinderProviderContext context);

        /// <inheritdoc cref="ModelBinderProviderBase.GetBinder(ModelBinderProviderContext)"/>
        public override IModelBinder? GetBinder(ModelBinderProviderContext context) => IsSuitable(context) ? new BinderTypeModelBinder(typeof(TModelBinder)) : default;
    }
}
