using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Base class for providers of model binders that can be automatically created as singletons.
    /// </summary>
    /// <typeparam name="TModelBinder">Model binder type.</typeparam>
    public abstract class SingletonModelBinderProviderBase<TModelBinder> : ModelBinderProviderBase where TModelBinder : IModelBinder, new()
    {
        /// <summary>
        /// Singleton instance of the model binder.
        /// </summary>
        public static readonly TModelBinder ModelBinderInstance = new TModelBinder();

        /// <summary>
        /// This method determines whether the model binder is suitable for the current context or not.
        /// </summary>
        /// <param name="context">The <see cref="ModelBinderProviderContext"/>.</param>
        /// <returns><see langword="true"/> if model binder is suitable; <see langword="false"/> otherwise.</returns>
        public abstract bool IsSuitable(ModelBinderProviderContext context);

        /// <inheritdoc cref="ModelBinderProviderBase.GetBinder(ModelBinderProviderContext)"/>
        public override IModelBinder? GetBinder(ModelBinderProviderContext context) => IsSuitable(context) ? ModelBinderInstance : default;
    }
}
