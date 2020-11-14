using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hastnama.Ekipchi.Api.Core.Extensions;

namespace OnlineShop.UI.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<string> GetPublicPropertiesNames(this Type type,
            Func<PropertyInfo, bool> filterBy = null)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => type.Name.Contains("AnonymousType") ? x.CanRead : x.CanWrite && x.CanRead)
                .AsEnumerable();

            if (filterBy != null)
                properties = properties.Where(filterBy);

            return properties.Select(x => x.Name)
                .OrderBy(x => x);
        }

        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type,
            Func<PropertyInfo, bool> filterBy = null)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => type.Name.Contains("AnonymousType") ? x.CanRead : x.CanWrite && x.CanRead)
                .AsEnumerable();

            if (filterBy != null)
                properties = properties.Where(filterBy);

            return properties.Select(x => x)
                .OrderBy(x => x.Name);
        }

        public static IEnumerable<PropertyInfo> GetStringTypeProperties(this Type type,
            Func<PropertyInfo, bool> filterBy = null)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => type.Name.Contains("AnonymousType")
                    ? x.CanRead && x.PropertyType == typeof(string)
                    : x.CanWrite && x.CanRead && x.PropertyType == typeof(string))
                .AsEnumerable();

            if (filterBy != null)
                properties = properties.Where(filterBy);

            return properties.Select(x => x)
                .OrderBy(x => x.Name);
        }

        public static Type GetBaseTypeEx(this Type type)
        {
            Argument.IsNotNull("type", type);
            return type.BaseType;
        }

        public static Type[] GetInterfacesEx(this Type type)
        {
            Argument.IsNotNull("type", type);
            return type.GetTypeInfo().ImplementedInterfaces.ToArray();
        }

        public static bool IsCOMObjectEx(this Type type)
        {
            Argument.IsNotNull("type", type);
            return type.IsCOMObject;
        }

        public static bool IsAssignableFromEx(this Type type, Type typeToCheck)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNull("typeToCheck", typeToCheck);

            return type.GetTypeInfo().IsAssignableFrom(typeToCheck.GetTypeInfo());
        }
    }
}