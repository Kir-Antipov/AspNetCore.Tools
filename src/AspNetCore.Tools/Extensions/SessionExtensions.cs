using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) helpful methods for objects
    /// that implement <see cref="ISession"/>.
    /// </summary>
    public static class SessionExtensions
    {
        /// <inheritdoc cref="Set(ISession, string, int)"/>
        public static void SetInt64(this ISession session, string key, long value) => session.Set(key, BitConverter.GetBytes(value));

        /// <inheritdoc cref="Set(ISession, string, int)"/>
        public static void SetBoolean(this ISession session, string key, bool value) => session.Set(key, new byte[] { (byte)(value ? 1 : 0) });


        /// <param name="session">The <see cref="ISession"/> instance.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        /// <inheritdoc cref="ISession.Set(string, byte[])"/>
        public static void Set(this ISession session, string key, int value) => session.SetInt32(key, value);

        /// <param name="session">The <see cref="ISession"/> instance.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can't be <see langword="null"/>.</param>
        /// <inheritdoc cref="ISession.Set(string, byte[])"/>
        public static void Set(this ISession session, string key, string value) => session.SetString(key, value ?? throw new ArgumentNullException(nameof(value)));

        /// <inheritdoc cref="Set(ISession, string, int)"/>
        public static void Set(this ISession session, string key, long value) => session.SetInt64(key, value);

        /// <inheritdoc cref="Set(ISession, string, int)"/>
        public static void Set(this ISession session, string key, bool value) => session.SetBoolean(key, value);


        /// <summary>
        /// Retrieve the value of the given key, if present; otherwise, <see langword="null"/>.
        /// </summary>
        /// <param name="session">The <see cref="ISession"/> instance.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value of the given key, if present; otherwise, <see langword="null"/>.</returns>
        public static long? GetInt64(this ISession session, string key) => TryGetValue(session, key, out long value) ? value : default(long?);

        /// <inheritdoc cref="GetInt64(ISession, string)"/>
        public static bool? GetBoolean(this ISession session, string key) => TryGetValue(session, key, out bool value) ? value : default(bool?);


        /// <summary>
        /// Retrieve the value of the given key, if present; otherwise, throws the <see cref="KeyNotFoundException"/>.
        /// </summary>
        /// <param name="session">The <see cref="ISession"/> instance.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value of the given key.</returns>
        /// <exception cref="KeyNotFoundException"/>
        public static int GetRequiredInt32(this ISession session, string key) => session.GetInt32(key) ?? throw new KeyNotFoundException(key);

        /// <inheritdoc cref="GetRequiredInt32(ISession, string)"/>
        public static long GetRequiredInt64(this ISession session, string key) => session.GetInt64(key) ?? throw new KeyNotFoundException(key);
        
        /// <inheritdoc cref="GetRequiredInt32(ISession, string)"/>
        public static string GetRequiredString(this ISession session, string key) => session.GetString(key) ?? throw new KeyNotFoundException(key);

        /// <inheritdoc cref="GetRequiredInt32(ISession, string)"/>
        public static bool GetRequiredBoolean(this ISession session, string key) => session.GetBoolean(key) ?? throw new KeyNotFoundException(key);


        /// <param name="session">The <see cref="ISession"/> instance.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the specified key,
        /// if the key is found; otherwise, the default value for the type of the value parameter.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the <see cref="ISession"/> contains an element with
        /// the specified key; otherwise, <see langword="false"/>.
        /// </returns>
        /// <inheritdoc cref="ISession.TryGetValue(string, out byte[])"/>
        public static bool TryGetValue(this ISession session, string key, out int value)
        {
            int? result = session.GetInt32(key);
            value = result ?? 0;
            return result.HasValue;
        }

        /// <inheritdoc cref="TryGetValue(ISession, string, out int)"/>
        public static bool TryGetValue(this ISession session, string key, [NotNullWhen(true)] out string? value) => (value = session.GetString(key)) is { };

        /// <inheritdoc cref="TryGetValue(ISession, string, out int)"/>
        public static bool TryGetValue(this ISession session, string key, out bool value)
        {
            if (session.Get(key) is { } bytes && bytes.Length > 0)
            {
                value = bytes[0] == 1;
                return true;
            }
            else
            {
                value = false;
                return false;
            }
        }

        /// <inheritdoc cref="TryGetValue(ISession, string, out int)"/>
        public static bool TryGetValue(this ISession session, string key, out long value)
        {
            if (session.Get(key) is { } bytes && bytes.Length > 0)
            {
                value = BitConverter.ToInt64(bytes, 0);
                return true;
            }
            else
            {
                value = 0L;
                return false;
            }
        }


        /// <inheritdoc cref="ContainsKey(ISession, string, IEqualityComparer{string})"/>
        public static bool ContainsKey(this ISession session, string key) => session.Keys.Contains(key);

        /// <summary>
        /// Determines whether the <see cref="ISession"/> contains the specified key.
        /// </summary>
        /// <param name="session">The <see cref="ISession"/> instance.</param>
        /// <param name="key">The key to <see cref="ISession"/>.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <returns>
        /// <see langword="true"/> if the <see cref="ISession"/> contains an element with
        /// the specified key; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool ContainsKey(this ISession session, string key, IEqualityComparer<string> comparer) => session.Keys.Contains(key, comparer);
    }
}
