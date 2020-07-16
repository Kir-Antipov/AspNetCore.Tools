using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AspNetCore.Tools.Helpers
{
    internal static class TypeHelper
    {
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this Type t) => t.GetCustomAttributes(inherit: false).OfType<TAttribute>();

        [return: MaybeNull]
        public static TAttribute GetCustomAttribute<TAttribute>(this Type t) => t.GetCustomAttributes<TAttribute>().FirstOrDefault();

        public static bool CouldBeInstance(this Type t) => (t.IsClass || t.IsValueType) && !t.IsAbstract && !t.IsGenericType;

        public static Type? FindImplementation(this Type t)
        {
            if (t.CouldBeInstance())
                return t;

            return ReflectionHelper.GetTypes().FirstOrDefault(x => t.IsAssignableFrom(x) && x.CouldBeInstance());
        }
    }
}
