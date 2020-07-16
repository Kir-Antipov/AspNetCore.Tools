using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Provides <see cref="ModelBinding.DoubleBinder"/>,
    /// <see cref="ModelBinding.DecimalBinder"/> and
    /// <see cref="ModelBinding.FloatBinder"/> model binders.
    /// </summary>
    public class NumberBinderProvider : ModelBinderProviderBase
    {
        private readonly DoubleBinder DoubleBinder;
        private readonly DecimalBinder DecimalBinder;
        private readonly FloatBinder FloatBinder;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBinderProvider"/> class.
        /// </summary>
        /// <param name="options">The <see cref="MvcOptions"/>.</param>
        [ActivatorUtilitiesConstructor]
        public NumberBinderProvider(MvcOptions options)
        {
            DoubleBinder = new DoubleBinder(options);
            DecimalBinder = new DecimalBinder(options);
            FloatBinder = new FloatBinder(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBinderProvider"/> class.
        /// </summary>
        /// <param name="errorMessageProvider">Error message provider based on model name.</param>
        public NumberBinderProvider(Func<string, string>? errorMessageProvider = null)
        {
            DoubleBinder = new DoubleBinder(errorMessageProvider);
            DecimalBinder = new DecimalBinder(errorMessageProvider);
            FloatBinder = new FloatBinder(errorMessageProvider);
        }

        /// <inheritdoc cref="ModelBinderProviderBase.GetBinder(ModelBinderProviderContext)"/>
        public override IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            Type modelType = context.Metadata.ModelType;

            if (modelType == typeof(double) || modelType == typeof(double?))
                return DoubleBinder;

            if (modelType == typeof(decimal) || modelType == typeof(decimal?))
                return DecimalBinder;

            if (modelType == typeof(float) || modelType == typeof(float?))
                return FloatBinder;

            return default;
        }
    }
}
