using System;
using System.Reflection;

namespace blazey.micro
{
    internal class Parameter
    {
        internal Type Type { get; private set; }
        internal string Name { get; private set; }
        public object Value { get; private set; }

        private Parameter(Type type, string name, object value = null)
        {
            Type = type;
            Name = name;
            Value = value;
        }

        internal static Parameter FromParameterInfo(ParameterInfo parameterInfo)
        {
            return new Parameter(parameterInfo.ParameterType, parameterInfo.Name);
        }

        internal static Parameter FromPropertyInfo(PropertyInfo propertyInfo, object instance)
        {
            return new Parameter(propertyInfo.PropertyType, propertyInfo.Name, propertyInfo.GetValue(instance, null));
        }
    }
}