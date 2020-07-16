using ProtoBuf;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace AspNetCore.Tools.Session
{
    /// <summary>
    /// Implementation of the <see cref="SessionValueSerializer{T}"/> for protobuf-net.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public class SessionProtobufNetSerializer<T> : SessionValueSerializer<T>
    {
        internal static SessionProtobufNetSerializer<T> Instance = Create<SessionProtobufNetSerializer<T>, T>();

        /// <inheritdoc cref="SessionValueSerializer{T}.Serialize(T)"/>
        protected override byte[] Serialize([DisallowNull] T value)
        {
            using MemoryStream memory = new MemoryStream();
            Serializer.Serialize(memory, value);
            return memory.ToArray();
        }

        /// <inheritdoc cref="SessionValueSerializer{T}.Deserialize(byte[])"/>
        [return: NotNull]
        protected override T Deserialize(byte[] data)
        {
            using MemoryStream memory = new MemoryStream(data);
            return Serializer.Deserialize<T>(memory)!;
        }
    }
}
