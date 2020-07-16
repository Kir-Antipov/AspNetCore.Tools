using System;

namespace AspNetCore.Tools.Services
{
    /// <summary>
    /// Indicates that property needs a service to be injected.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class InjectServiceAttribute : Attribute { }
}
