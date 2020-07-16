using AspNetCore.Tools.Session;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) helpful methods for objects
    /// that implement <see cref="ISession"/>.
    /// </summary>
    public static class SessionProtobufNetExtensions
    {
        /// <inheritdoc cref="SessionExtensions.Set(ISession, string, int)"/>
        public static void Set<T>(this ISession session, string key, [DisallowNull] T value) => SessionProtobufNetSerializer<T>.Instance.Set(session, key, value);

        /// <inheritdoc cref="SessionExtensions.GetInt64(ISession, string)"/>
        [return: MaybeNull]
        public static T Get<T>(this ISession session, string key) => SessionProtobufNetSerializer<T>.Instance.Get(session, key);

        /// <inheritdoc cref="SessionExtensions.GetRequiredInt64(ISession, string)"/>
        [return: NotNull]
        public static T GetRequired<T>(this ISession session, string key) => SessionProtobufNetSerializer<T>.Instance.GetRequired(session, key);

        /// <inheritdoc cref="SessionExtensions.TryGetValue(ISession, string, out string?)"/>
        public static bool TryGetValue<T>(this ISession session, string key, [MaybeNull, NotNullWhen(true)] out T value) => SessionProtobufNetSerializer<T>.Instance.TryGetValue(session, key, out value);
    }
}
