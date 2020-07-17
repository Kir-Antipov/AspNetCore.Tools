using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Generic version of the <see cref="ModelParserBase"/>.
    /// </summary>
    /// <typeparam name="TModel">Model type.</typeparam>
    public abstract class ModelParserBase<TModel> : ModelParserBase
    {
        /// <inheritdoc cref="ModelParserBase.TryParse(string, out object?)"/>
        public sealed override bool TryParse(string value, out object? result)
        {
            bool success = TryParse(value, out TModel model);
            result = model;
            return success;
        }

        /// <inheritdoc cref="TryParse(string, out object?)"/>
        public abstract bool TryParse(string value, [MaybeNull, NotNullWhen(true)] out TModel result);
    }
}
