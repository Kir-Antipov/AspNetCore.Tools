using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Tools.Helpers
{
    internal static class ReflectionHelper
    {
        private static readonly string[] DefaultAssemblies = new[]
        {
            "Microsoft",
            "mscorlib",
            "netstandard",
            "Newtonsoft.Json",
            "System"
        };

        public static IEnumerable<Assembly> GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies()
            .Where(x => !x.IsDynamic && !IsDefaultAssembly(x));

        public static IEnumerable<Type> GetTypes() => GetAssemblies().SelectMany(x => { try { return x.GetTypes(); } catch { return Array.Empty<Type>(); } });

        public static IEnumerable<(Type Type, TAttribute Attribute)> GetMarkedTypes<TAttribute>() => GetTypes()
            .Select(x => (Type: x, Attribute: x.GetCustomAttribute<TAttribute>()))
            .Where(x => x.Attribute is { });

        private static bool IsDefaultAssembly(Assembly assembly) => string.IsNullOrEmpty(assembly.FullName) || DefaultAssemblies.Any(assembly.FullName.StartsWith);
    }
}
