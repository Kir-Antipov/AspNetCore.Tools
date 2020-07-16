using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SessionExtensions = AspNetCore.Tools.Extensions.SessionExtensions;

namespace AspNetCore.Tools.Session
{
    /// <summary>
    /// Base class for the <typeparamref name="T"/> serializers.
    /// </summary>
    public abstract class SessionValueSerializer<T> : SessionValueSerializer
    {
        /// <inheritdoc cref="SessionExtensions.Set(ISession, string, int)"/>
        public virtual void Set(ISession session, string key, T value) => session.Set(key, Serialize(value ?? throw new ArgumentNullException(nameof(value))));

        /// <inheritdoc cref="SessionExtensions.TryGetValue(ISession, string, out string?)"/>
        public virtual bool TryGetValue(ISession session, string key, [MaybeNull, NotNullWhen(true)] out T value)
        {
            if (session.Get(key) is { } bytes)
            {
                value = Deserialize(bytes);
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        /// <inheritdoc cref="SessionExtensions.GetInt64(ISession, string)"/>
        [return: MaybeNull]
        public T Get(ISession session, string key) => TryGetValue(session, key, out T value) ? value : default;

        /// <inheritdoc cref="SessionExtensions.GetRequiredInt64(ISession, string)"/>
        [return: NotNull]
        public T GetRequired(ISession session, string key) => TryGetValue(session, key, out T value) ? value : throw new KeyNotFoundException(key);

        /// <summary>
        /// Serializes an entity to a byte array.
        /// </summary>
        /// <param name="value">Entity instance.</param>
        /// <returns>Serialized entity.</returns>
        protected virtual byte[] Serialize([DisallowNull] T value) => throw new NotImplementedException();

        /// <summary>
        /// Deserializes an entity from byte array.
        /// </summary>
        /// <param name="data">Serialized entity.</param>
        /// <returns>Entity instance.</returns>
        [return: NotNull]
        protected virtual T Deserialize(byte[] data) => throw new NotImplementedException();
    }
}
