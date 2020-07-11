using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Attempts to bind a <see cref="string"/> to <see cref="double"/>.
    /// </summary>
    /// <remarks>
    /// This model binder uses <see cref="CultureInfo.InvariantCulture"/>
    /// and also treats points and commas equally as a separator of the 
    /// integer and fractional part of a number.
    /// So your web application won't break suddenly due to a changed culture.
    /// </remarks>
    public class DoubleBinder : ModelParserBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBinder"/> class.
        /// </summary>
        /// <param name="options">The <see cref="MvcOptions"/>.</param>
        [ActivatorUtilitiesConstructor]
        public DoubleBinder(MvcOptions options) : base(options.ModelBindingMessageProvider.ValueMustBeANumberAccessor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBinder"/> class.
        /// </summary>
        /// <param name="errorMessageProvider">Error message provider based on model name.</param>
        public DoubleBinder(Func<string, string>? errorMessageProvider = null) : base(errorMessageProvider) { }

        /// <inheritdoc cref="ModelParserBase.TryParse(string, out object?)"/>
        public override bool TryParse(string value, [NotNullWhen(true)] out object? result)
        {
            if (double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                result = number;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
