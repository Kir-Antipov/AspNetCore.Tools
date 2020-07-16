using System;

namespace AspNetCore.Tools.ModelBinding
{
    /// <summary>
    /// Marks class as a model binder provider that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class ModelBinderProviderAttribute : Attribute
    {
        /// <summary>
        /// The priority of this model binder provider against others
        /// (the higher the priority, the earlier model binder provider will be launched).
        /// </summary>
        public int Priority { get; set; }
    }
}
