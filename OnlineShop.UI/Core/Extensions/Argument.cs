using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using OnlineShop.UI.Core.Extensions;

// ReSharper disable All

namespace Hastnama.Ekipchi.Api.Core.Extensions
{
    public static class Argument
    {
        public static void IsNotNull(string paramName, object paramValue)
        {
            if (paramValue == null)
            {
                var error = $"Argument '{paramName}' cannot be null";
                throw new ArgumentNullException(paramName, error);
            }
        }

        public static void IsNotNullOrEmpty(string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                var error = $"Argument '{paramName}' cannot be null or empty";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsNotEmpty(string paramName, Guid paramValue)
        {
            if (paramValue == Guid.Empty)
            {
                var error = $"Argument '{paramName}' cannot be Guid.Empty";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsNotNullOrEmpty(string paramName, Guid? paramValue)
        {
            if (!paramValue.HasValue || paramValue.Value == Guid.Empty)
            {
                var error = $"Argument '{paramName}' cannot be null or Guid.Empty";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsNotNullOrWhitespace(string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue) || (string.CompareOrdinal(paramValue.Trim(), string.Empty) == 0))
            {
                var error = $"Argument '{paramName}' cannot be null or whitespace";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsNotNullOrEmptyArray(string paramName, Array paramValue)
        {
            if ((paramValue == null) || (paramValue.Length == 0))
            {
                var error = $"Argument '{paramName}' cannot be null or an empty array";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsNotOutOfRange<T>(string paramName, T paramValue, T minimumValue, T maximumValue,
            Func<T, T, T, bool> validation)
        {
            IsNotNull("validation", validation);

            if (!validation(paramValue, minimumValue, maximumValue))
            {
                var error = $"Argument '{paramName}' cannot be null or an empty array";
                throw new ArgumentOutOfRangeException(paramName, error);
            }
        }

        public static void IsNotOutOfRange<T>(string paramName, T paramValue, T minimumValue, T maximumValue)
            where T : IComparable
        {
            IsNotOutOfRange(paramName, paramValue, minimumValue, maximumValue,
                (innerParamValue, innerMinimumValue, innerMaximumValue) =>
                    innerParamValue.CompareTo(innerMinimumValue) >= 0 &&
                    innerParamValue.CompareTo(innerMaximumValue) <= 0);
        }

        public static void IsMinimal<T>(string paramName, T paramValue, T minimumValue, Func<T, T, bool> validation)
        {
            IsNotNull("validation", validation);

            if (!validation(paramValue, minimumValue))
            {
                var error = $"Argument '{paramName}' should be minimal {minimumValue}";
                throw new ArgumentOutOfRangeException(paramName, error);
            }
        }

        public static void IsMinimal<T>(string paramName, T paramValue, T minimumValue)
            where T : IComparable
        {
            IsMinimal(paramName, paramValue, minimumValue,
                (innerParamValue, innerMinimumValue) => innerParamValue.CompareTo(innerMinimumValue) >= 0);
        }

        public static void IsMaximum<T>(string paramName, T paramValue, T maximumValue, Func<T, T, bool> validation)
        {
            if (!validation(paramValue, maximumValue))
            {
                var error = $"Argument '{paramName}' should be minimal {maximumValue}";
                throw new ArgumentOutOfRangeException(paramName, error);
            }
        }

        public static void IsMaximum<T>(string paramName, T paramValue, T maximumValue)
            where T : IComparable
        {
            IsMaximum(paramName, paramValue, maximumValue,
                (innerParamValue, innerMaximumValue) => innerParamValue.CompareTo(innerMaximumValue) <= 0);
        }

        public static void InheritsFrom(string paramName, Type type, Type baseType)
        {
            IsNotNull("type", type);
            IsNotNull("baseType", baseType);

            var runtimeBaseType = type.GetBaseTypeEx();

            do
            {
                if (runtimeBaseType == baseType)
                {
                    return;
                }

                // Prevent some endless while loops
                if (runtimeBaseType == typeof(Object))
                {
                    // Break, no return because this should cause an exception
                    break;
                }

                runtimeBaseType = type.GetBaseTypeEx();
            } while (runtimeBaseType != null);

            var error = $"Type '{type.Name}' should have type '{baseType.Name}' as base class, but does not";
            throw new ArgumentException(error, paramName);
        }

        public static void InheritsFrom(string paramName, object instance, Type baseType)
        {
            IsNotNull("instance", instance);

            InheritsFrom(paramName, instance.GetType(), baseType);
        }

        public static void InheritsFrom<TBase>(string paramName, object instance)
            where TBase : class
        {
            var baseType = typeof(TBase);

            InheritsFrom(paramName, instance, baseType);
        }

        public static void ImplementsInterface(string paramName, object instance, Type interfaceType)
        {
            Argument.IsNotNull("instance", instance);

            ImplementsInterface(paramName, instance.GetType(), interfaceType);
        }

        public static void ImplementsInterface<TInterface>(string paramName, object instance)
            where TInterface : class
        {
            var interfaceType = typeof(TInterface);

            ImplementsInterface(paramName, instance, interfaceType);
        }

        public static void ImplementsInterface(string paramName, Type type, Type interfaceType)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNull("interfaceType", interfaceType);

            if (type.GetInterfacesEx().Any(iType => iType == interfaceType))
            {
                return;
            }

            var error = $"Type '{type.Name}' should implement interface '{interfaceType.Name}', but does not";
            throw new ArgumentException(error, paramName);
        }

        public static void ImplementsOneOfTheInterfaces(string paramName, object instance, Type[] interfaceTypes)
        {
            Argument.IsNotNull("instance", instance);

            ImplementsOneOfTheInterfaces(paramName, instance.GetType(), interfaceTypes);
        }

        public static void ImplementsOneOfTheInterfaces(string paramName, Type type, Type[] interfaceTypes)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNullOrEmptyArray("interfaceTypes", interfaceTypes);

            foreach (var interfaceType in interfaceTypes)
            {
                if (type.GetInterfacesEx().Any(iType => iType == interfaceType))
                {
                    return;
                }
            }

            var errorBuilder = new StringBuilder();
            errorBuilder.AppendLine(
                "Type '{0}' should implement at least one of the following interfaces, but does not:");
            foreach (var interfaceType in interfaceTypes)
            {
                errorBuilder.AppendLine("  * " + interfaceType.FullName);
            }

            var error = errorBuilder.ToString();
            throw new ArgumentException(error, paramName);
        }

        public static void IsOfType(string paramName, object instance, Type requiredType)
        {
            Argument.IsNotNull("instance", instance);

            IsOfType(paramName, instance.GetType(), requiredType);
        }

        public static void IsOfType(string paramName, Type type, Type requiredType)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNull("requiredType", requiredType);

            if (type.IsCOMObjectEx())
            {
                return;
            }

            if (requiredType.IsAssignableFromEx(type))
            {
                return;
            }

            var error = $"Type '{type.Name}' should be of type '{requiredType.Name}', but is not";
            throw new ArgumentException(error, paramName);
        }

        public static void IsOfOneOfTheTypes(string paramName, object instance, Type[] requiredTypes)
        {
            Argument.IsNotNull("instance", instance);

            IsOfOneOfTheTypes(paramName, instance.GetType(), requiredTypes);
        }

        public static void IsOfOneOfTheTypes(string paramName, Type type, Type[] requiredTypes)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNullOrEmptyArray("requiredTypes", requiredTypes);

            if (type.IsCOMObjectEx())
            {
                return;
            }

            foreach (var requiredType in requiredTypes)
            {
                if (requiredType.IsAssignableFromEx(type))
                {
                    return;
                }
            }

            var errorBuilder = new StringBuilder();
            errorBuilder.AppendLine("Type '{0}' should implement at least one of the following types, but does not:");
            foreach (var requiredType in requiredTypes)
            {
                errorBuilder.AppendLine("  * " + requiredType.FullName);
            }

            var error = errorBuilder.ToString();
            throw new ArgumentException(error, paramName);
        }

        public static void IsNotOfType(string paramName, object instance, Type notRequiredType)
        {
            Argument.IsNotNull("instance", instance);

            IsNotOfType(paramName, instance.GetType(), notRequiredType);
        }

        public static void IsNotOfType(string paramName, Type type, Type notRequiredType)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNull("notRequiredType", notRequiredType);

            if (type.IsCOMObjectEx())
            {
                return;
            }

            if (!notRequiredType.IsAssignableFromEx(type))
            {
                return;
            }

            var error = $"Type '{type.Name}' should not be of type '{notRequiredType.Name}', but is";
            throw new ArgumentException(error, paramName);
        }

        public static void IsNotOfOneOfTheTypes(string paramName, object instance, Type[] notRequiredTypes)
        {
            Argument.IsNotNull("instance", instance);

            IsNotOfOneOfTheTypes(paramName, instance.GetType(), notRequiredTypes);
        }

        public static void IsNotOfOneOfTheTypes(string paramName, Type type, Type[] notRequiredTypes)
        {
            Argument.IsNotNull("type", type);
            Argument.IsNotNullOrEmptyArray("notRequiredTypes", notRequiredTypes);

            if (type.IsCOMObjectEx())
            {
                return;
            }

            foreach (var notRequiredType in notRequiredTypes)
            {
                if (notRequiredType.IsAssignableFromEx(type))
                {
                    var error = $"Type '{type.Name}' should not be of type '{notRequiredType.Name}', but is";
                    throw new ArgumentException(error, paramName);
                }
            }
        }

        public static void IsNotMatch(string paramName, string paramValue, string pattern,
            RegexOptions regexOptions = RegexOptions.None)
        {
            Argument.IsNotNull("paramValue", paramValue);
            Argument.IsNotNull("pattern", pattern);

            if (Regex.IsMatch(paramValue, pattern, regexOptions))
            {
                var error = $"Argument '{paramName}' matches with pattern '{pattern}'";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsMatch(string paramName, string paramValue, string pattern,
            RegexOptions regexOptions = RegexOptions.None)
        {
            Argument.IsNotNull("paramValue", paramValue);
            Argument.IsNotNull("pattern", pattern);

            if (!Regex.IsMatch(paramValue, pattern, regexOptions))
            {
                var error = $"Argument '{paramName}' doesn't match with pattern '{pattern}'";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsValid<T>(string paramName, T paramValue, Func<bool> validation)
        {
            Argument.IsNotNull("validation", validation);

            IsValid(paramName, paramValue, validation.Invoke());
        }

        public static void IsValid<T>(string paramName, T paramValue, Func<T, bool> validation)
        {
            Argument.IsNotNull("validation", validation);

            IsValid(paramName, paramValue, validation.Invoke(paramValue));
        }

      

        public static void IsValid<T>(string paramName, T paramValue, bool validation)
        {
            if (!validation)
            {
                var error = $"Argument '{paramName}' is not valid";
                throw new ArgumentException(error, paramName);
            }
        }

        public static void IsSupported(bool isSupported, string errorFormat, params object[] args)
        {
            Argument.IsNotNullOrWhitespace("errorFormat", errorFormat);

            if (!isSupported)
            {
                var error = string.Format(errorFormat, args);
                throw new NotSupportedException(error);
            }
        }

        private static ParameterInfo<T> GetParameterInfo<T>(Expression<Func<T>> expression)
        {
            IsNotNull("expression", expression);

            var parameterExpression = (MemberExpression)expression.Body;
            var parameterInfo = new ParameterInfo<T>(parameterExpression.Member.Name, expression.Compile().Invoke());

            return parameterInfo;
        }

        public static void IsNotNull<T>(Expression<Func<T>> expression)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotNull(parameterInfo.Name, parameterInfo.Value);
        }

        public static void IsNotNullOrEmpty(Expression<Func<string>> expression)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotNullOrEmpty(parameterInfo.Name, (string)parameterInfo.Value);
        }

        public static void IsNotEmpty(Expression<Func<Guid>> expression)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotEmpty(parameterInfo.Name, (Guid)parameterInfo.Value);
        }

        public static void IsNotNullOrEmpty(Expression<Func<Guid?>> expression)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotNullOrEmpty(parameterInfo.Name, (Guid?)parameterInfo.Value);
        }

        public static void IsNotNullOrWhitespace(Expression<Func<string>> expression)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotNullOrWhitespace(parameterInfo.Name, (string)parameterInfo.Value);
        }

        public static void IsNotNullOrEmptyArray(Expression<Func<Array>> expression)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotNullOrEmptyArray(parameterInfo.Name, (Array)parameterInfo.Value);
        }

        public static void IsNotOutOfRange<T>(Expression<Func<T>> expression, T minimumValue, T maximumValue,
            Func<T, T, T, bool> validation)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotOutOfRange(parameterInfo.Name, (T)parameterInfo.Value, minimumValue, maximumValue, validation);
        }

        public static void IsNotOutOfRange<T>(Expression<Func<T>> expression, T minimumValue, T maximumValue)
            where T : IComparable
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotOutOfRange(parameterInfo.Name, (T)parameterInfo.Value, minimumValue, maximumValue);
        }

        public static void IsMinimal<T>(Expression<Func<T>> expression, T minimumValue, Func<T, T, bool> validation)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsMinimal(parameterInfo.Name, (T)parameterInfo.Value, minimumValue, validation);
        }

        public static void IsMinimal<T>(Expression<Func<T>> expression, T minimumValue)
            where T : IComparable
        {
            var parameterInfo = GetParameterInfo(expression);
            IsMinimal(parameterInfo.Name, (T)parameterInfo.Value, minimumValue);
        }

        public static void IsMaximum<T>(Expression<Func<T>> expression, T maximumValue, Func<T, T, bool> validation)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsMaximum(parameterInfo.Name, (T)parameterInfo.Value, maximumValue, validation);
        }

        public static void IsMaximum<T>(Expression<Func<T>> expression, T maximumValue)
            where T : IComparable
        {
            var parameterInfo = GetParameterInfo(expression);
            IsMaximum(parameterInfo.Name, (T)parameterInfo.Value, maximumValue);
        }

        public static void ImplementsInterface<T>(Expression<Func<T>> expression, Type interfaceType)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            if (parameterInfo.Value is Type)
            {
                ImplementsInterface(parameterInfo.Name, (T)parameterInfo.Value as Type, interfaceType);
            }
            else
            {
                ImplementsInterface(parameterInfo.Name, parameterInfo.Value.GetType(), interfaceType);
            }
        }

        public static void ImplementsOneOfTheInterfaces<T>(Expression<Func<T>> expression, Type[] interfaceTypes)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            if (parameterInfo.Value is Type)
            {
                ImplementsOneOfTheInterfaces(parameterInfo.Name, (T)parameterInfo.Value as Type, interfaceTypes);
            }
            else
            {
                ImplementsOneOfTheInterfaces(parameterInfo.Name, parameterInfo.Value.GetType(), interfaceTypes);
            }
        }

        public static void IsOfType<T>(Expression<Func<T>> expression, Type requiredType)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            if (parameterInfo.Value is Type)
            {
                IsOfType(parameterInfo.Name, (T)parameterInfo.Value as Type, requiredType);
            }
            else
            {
                IsOfType(parameterInfo.Name, parameterInfo.Value.GetType(), requiredType);
            }
        }

        public static void IsOfOneOfTheTypes<T>(Expression<Func<T>> expression, Type[] requiredTypes)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            if (parameterInfo.Value is Type)
            {
                IsOfOneOfTheTypes(parameterInfo.Name, (T)parameterInfo.Value as Type, requiredTypes);
            }
            else
            {
                IsOfOneOfTheTypes(parameterInfo.Name, parameterInfo.Value.GetType(), requiredTypes);
            }
        }

        public static void IsNotOfType<T>(Expression<Func<T>> expression, Type notRequiredType)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            if (parameterInfo.Value is Type)
            {
                IsNotOfType(parameterInfo.Name, (T)parameterInfo.Value as Type, notRequiredType);
            }
            else
            {
                IsNotOfType(parameterInfo.Name, parameterInfo.Value.GetType(), notRequiredType);
            }
        }

        public static void IsNotOfOneOfTheTypes<T>(Expression<Func<T>> expression, Type[] notRequiredTypes)
            where T : class
        {
            var parameterInfo = GetParameterInfo(expression);
            if (parameterInfo.Value is Type)
            {
                IsNotOfOneOfTheTypes(parameterInfo.Name, (T)parameterInfo.Value as Type, notRequiredTypes);
            }
            else
            {
                IsNotOfOneOfTheTypes(parameterInfo.Name, parameterInfo.Value.GetType(), notRequiredTypes);
            }
        }

        public static void IsNotMatch(Expression<Func<string>> expression, string pattern,
            RegexOptions regexOptions = RegexOptions.None)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsNotMatch(parameterInfo.Name, (string)parameterInfo.Value, pattern, regexOptions);
        }

        public static void IsMatch(Expression<Func<string>> expression, string pattern,
            RegexOptions regexOptions = RegexOptions.None)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsMatch(parameterInfo.Name, (string)parameterInfo.Value, pattern, regexOptions);
        }

        public static void IsValid<T>(Expression<Func<T>> expression, Func<T, bool> validation)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsValid(parameterInfo.Name, (T)parameterInfo.Value, validation);
        }

        public static void IsValid<T>(Expression<Func<T>> expression, Func<bool> validation)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsValid(parameterInfo.Name, (T)parameterInfo.Value, validation);
        }

        public static void IsValid<T>(Expression<Func<T>> expression, bool validation)
        {
            var parameterInfo = GetParameterInfo(expression);
            IsValid(parameterInfo.Name, (T)parameterInfo.Value, validation);
        }


        /// <summary>
        /// The parameter info.
        /// </summary>
        private class ParameterInfo<T>
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ParameterInfo{T}" /> class.
            /// </summary>
            /// <param name="name">The parameter name.</param>
            /// <param name="value">The value.</param>
            public ParameterInfo(string name, T value)
            {
                Name = name;
                Value = value;
            }

            #endregion Constructors

            #region Properties

            /// <summary>
            /// Gets the value.
            /// </summary>
            public T Value { get; }

            /// <summary>
            /// Gets the name.
            /// </summary>
            public string Name { get; }

            #endregion Properties
        }
    }
}