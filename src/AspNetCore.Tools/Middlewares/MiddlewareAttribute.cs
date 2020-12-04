using System;

namespace AspNetCore.Tools.Middlewares
{
    /// <summary>
    /// Marks class as a middleware that needs to be registered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public class MiddlewareAttribute : Attribute
    {
        /// <summary>
        /// The priority of this middleware against others (the higher the priority, the earlier this middleware will be launched).
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// The arguments to pass to the middleware type instance's constructor.
        /// </summary>
        public object[] Arguments { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiddlewareAttribute"/> class.
        /// </summary>
        /// <param name="priority">The priority of this middleware against others (the higher the priority, the earlier this middleware will be launched).</param>
        /// <param name="args">The arguments to pass to the middleware type instance's constructor.</param>
        public MiddlewareAttribute(int priority = 0, params object[]? args) => (Priority, Arguments) = (priority, args ?? Array.Empty<object>());
    }
}
