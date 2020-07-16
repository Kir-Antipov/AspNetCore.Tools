using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Asynchronous version of <see cref="ModelParserBase"/>.
    /// </summary>
    public abstract class AsyncModelParserBase : ModelBinderBase
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
        public AsyncModelParserBase(Func<string, string>? errorMessageProvider = null) => ErrorMessageProvider = errorMessageProvider ?? DefaultErrorMessageProvider;

        /// <inheritdoc cref="ModelBinderBase.BindModelAsync(ModelBindingContext)"/>
        public override async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string modelName = bindingContext.ModelName;
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
                return;

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string valueStr = valueProviderResult.FirstValue;
            if (await TryParseAsync(valueStr) is (true, object result))
            {
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, ErrorMessageProvider(bindingContext.ModelName));
            }
        }

        /// <summary>
        /// Attempts to parse a string into a model.
        /// </summary>
        /// <param name="value">String representation of a model.</param>
        /// <returns>
        /// A <see cref="Task"/> that represents the completion of model parsing.
        /// </returns>
        public abstract Task<(bool success, object? result)> TryParseAsync(string value);
    }
}
