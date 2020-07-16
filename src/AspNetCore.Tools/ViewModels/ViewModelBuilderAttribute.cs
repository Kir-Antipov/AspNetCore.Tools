using System;

namespace AspNetCore.Tools.ViewModels
{
    /// <summary>
    /// Marks class as a valid ViewModelBuilder to be used.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class ViewModelBuilderAttribute : Attribute
    {
        /// <summary>
        /// Model type associated with this ViewModelBuilder.
        /// </summary>
        public Type? ViewModelType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBuilderAttribute"/> class.
        /// </summary>
        /// <param name="viewModelType">Model type associated with this ViewModelBuilder.</param>
        public ViewModelBuilderAttribute(Type? viewModelType = null) => ViewModelType = viewModelType;
    }
}
