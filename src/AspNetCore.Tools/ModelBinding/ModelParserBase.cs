using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Base class for model binders, eliminating the need to write a bunch of boilerplate.
    /// </summary>
    public abstract class ModelParserBase : ModelBinderBase
    {
        /// <summary>
        /// Default error message provider.
        /// </summary>
        public static readonly Func<string, string> DefaultErrorMessageProvider = x => new FormatException().Message;

        /// <summary>
        /// Error message provider based on model name.
        /// </summary>
        public readonly Func<string, string> ErrorMessageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelParserBase"/> class.
        /// </summary>
        /// <param name="errorMessageProvider">Error message provider based on model name.</param>
        public ModelParserBase(Func<string, string>? errorMessageProvider = null) => ErrorMessageProvider = errorMessageProvider ?? DefaultErrorMessageProvider;

        /// <inheritdoc cref="ModelBinderBase.BindModelAsync(ModelBindingContext)"/>
        public override Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string modelName = bindingContext.ModelName;
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string valueStr = valueProviderResult.FirstValue ?? string.Empty;
            if (!TryParse(valueStr, out object? result))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, ErrorMessageProvider(bindingContext.ModelName));
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Attempts to parse a string into a model.
        /// </summary>
        /// <param name="value">String representation of a model.</param>
        /// <param name="result">Parsed model.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> was parsed successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public abstract bool TryParse(string value, out object? result);
    }
}
