using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AspNetCore.Tools.Session.NewtonsoftJson.Session
{
    /// <summary>
    /// Implementation of the <see cref="SessionValueSerializer{T}"/> for Newtonsoft.Json.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public class SessionNewtonsoftJsonSerializer<T> : SessionValueSerializer<T>
    {
        internal static SessionNewtonsoftJsonSerializer<T> Instance = Create<SessionNewtonsoftJsonSerializer<T>, T>();

        /// <inheritdoc cref="SessionValueSerializer{T}.Serialize(T)"/>
        protected override byte[] Serialize([DisallowNull] T value) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value));

        /// <inheritdoc cref="SessionValueSerializer{T}.Deserialize(byte[])"/>
        [return: NotNull]
        protected override T Deserialize(byte[] data) => JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data))!;
    }
}
