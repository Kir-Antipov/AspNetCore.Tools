using System.Threading.Tasks;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Generic version of the <see cref="AsyncModelParserBase"/>.
    /// </summary>
    /// <typeparam name="TModel">Model type.</typeparam>
    public abstract class AsyncModelParserBase<TModel> : AsyncModelParserBase
    {
        /// <inheritdoc cref="AsyncModelParserBase.TryParseAsync(string)"/>
        public sealed override async Task<(bool success, object? result)> TryParseAsync(string value) => await TryParseModelAsync(value);

        /// <inheritdoc cref="TryParseAsync(string)"/>
        public abstract Task<(bool success, TModel result)> TryParseModelAsync(string value);
    }
}
