using AspNetCore.Tools.Helpers;
using AspNetCore.Tools.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) helpful methods for objects
    /// that implement <see cref="MvcOptions"/>.
    /// </summary>
    public static class MvcOptionsExtensions
    {
        /// <inheritdoc cref="UseNumberModelBinder(MvcOptions, Func{string, string}?)"/>
        public static MvcOptions UseNumberModelBinder(this MvcOptions options) => options.UseNumberModelBinder(null);

        /// <summary>
        /// Registers <see cref="NumberBinderProvider"/> as model binder provider.
        /// </summary>
        /// <param name="options">The <see cref="MvcOptions"/> instance.</param>
        /// <param name="errorMessageProvider">Error message provider based on model name.</param>
        /// <returns>The <see cref="MvcOptions"/> instance.</returns>
        public static MvcOptions UseNumberModelBinder(this MvcOptions options, Func<string, string>? errorMessageProvider)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));

            options.ModelBinderProviders.Insert(0, new NumberBinderProvider(errorMessageProvider ?? options.ModelBindingMessageProvider.ValueMustBeANumberAccessor));
            return options;
        }

        /// <summary>
        /// Registers all model binder providers marked with <see cref="ModelBinderProviderAttribute"/>.
        /// </summary>
        /// <param name="options">The <see cref="MvcOptions"/> instance.</param>
        /// <param name="skipOnFailure">Indicates whether the method should be aborted if an exception occurs.</param>
        /// <returns>The <see cref="MvcOptions"/> instance.</returns>
        public static MvcOptions UseMarkedModelBinderProviders(this MvcOptions options, bool skipOnFailure = false)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));

            var modelBinderProviders = ReflectionHelper.GetMarkedTypes<AutoModelBinderAttribute>()
                .Select(data =>
                {
                    try
                    {
                        ModelBinderProviderAttribute newAttribute = new ModelBinderProviderAttribute { Priority = data.Attribute.Priority };

                        return data.Attribute.ModelBinderProvider is { } ?
                            (Type: data.Attribute.ModelBinderProvider, Attribute: newAttribute) :
                            (Type: AutoModelBinderProvider.Create(data.Type, data.Attribute.SupportedTypes), Attribute: newAttribute);
                    }
                    catch
                    {
                        if (!skipOnFailure)
                            throw;

                        return (null, null)!;
                    }
                })
                .Where(x => x.Type is { })
                .Concat(ReflectionHelper.GetMarkedTypes<ModelBinderProviderAttribute>())
                .OrderByDescending(x => x.Attribute.Priority);

            int lastIndex = 0;
            foreach (var (type, attr) in modelBinderProviders)
            {
                if (!type.CouldBeInstance() || !typeof(IModelBinderProvider).IsAssignableFrom(type) || type.GetConstructor(Type.EmptyTypes) is null)
                    if (skipOnFailure)
                        continue;
                    else
                        throw new TypeLoadException($"It's not possible to create an instance of {type.FullName} and/or cast it to {typeof(IModelBinderProvider).FullName}.");

                IModelBinderProvider modelBinderProvider = (IModelBinderProvider)Activator.CreateInstance(type)!;

                if (attr.Priority >= 0)
                    options.ModelBinderProviders.Insert(lastIndex++, modelBinderProvider);
                else
                    options.ModelBinderProviders.Add(modelBinderProvider);
            }

            return options;
        }
    }
}
