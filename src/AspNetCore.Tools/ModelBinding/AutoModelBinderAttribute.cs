using System;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Provides information about an associated model binder provider.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class AutoModelBinderAttribute : Attribute
    {
        /// <summary>
        /// Types supported by marked model binder.
        /// </summary>
        public Type[] SupportedTypes { get; }

        /// <summary>
        /// Associated model binder provider that must be registered.
        /// </summary>
        public Type? ModelBinderProvider { get; set; }

        /// <summary>
        /// The priority of associated model binder provider against others
        /// (the higher the priority, the earlier model binder provider will be launched).
        /// </summary>
        public int Priority { get; set; }

        /// <inheritdoc cref="AutoModelBinderAttribute(Type[])"/>
        public AutoModelBinderAttribute() : this(Type.EmptyTypes) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoModelBinderAttribute"/> class.
        /// </summary>
        /// <param name="supportedTypes">
        /// Types supported by marked model binder.
        /// <para/>
        /// They're necessary for the automatic generation of model binder provider.
        /// </param>
        public AutoModelBinderAttribute(params Type[] supportedTypes) => SupportedTypes = supportedTypes ?? Type.EmptyTypes;
    }
}
