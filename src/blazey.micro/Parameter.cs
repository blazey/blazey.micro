using System;
using System.Diagnostics;
using System.Reflection;

namespace blazey.micro
{
    [DebuggerDisplay("{ToString()}")]
    internal class Parameter
    {
        private readonly Type _sourceType;
        internal Type Type { get; private set; }
        internal string Name { get; private set; }
        public object Value { get; private set; }

        private Parameter(Type sourceType, Type type, string name, object value = null)
        {
            _sourceType = sourceType;
            Type = type;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            var value = Value;
            string valueType;
            if (null == Value)
            {
                value = string.Empty;
                valueType = "null";
            }
            else
            {
                valueType = Value.GetType().Name;
            }
            
            return string.Format("SourceType: {0}, Type: {1}, Name: '{2}', Value: '{3}' {4}", _sourceType.Name, Type.Name, Name, value, valueType);
        }

        internal static Parameter FromParameterInfo(ParameterInfo parameterInfo)
        {
            return new Parameter(parameterInfo.GetType(), parameterInfo.ParameterType, parameterInfo.Name);
        }

        internal static Parameter FromPropertyInfo(PropertyInfo propertyInfo, object instance)
        {
            return new Parameter(propertyInfo.GetType(), propertyInfo.PropertyType, propertyInfo.Name, propertyInfo.GetValue(instance, null));
        }
    }
}