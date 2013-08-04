using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace blazey.micro
{
    public class ModelActivator
    {
        public T Activate<T>(object source)
        {
            var toActivateType = typeof (T);
            //order by scope, then length
            var constructor = toActivateType.GetConstructors(
                BindingFlags.NonPublic |
                BindingFlags.CreateInstance |
                BindingFlags.Instance).OrderByDescending(ctor => ctor.GetParameters().Length).FirstOrDefault();

            if (null == constructor)
            {
                throw new InvalidOperationException("No accessible constructor");
            }

            if (null == constructor.GetParameters().FirstOrDefault())
            {
                throw new InvalidOperationException("No accessible constructor");
            }

            var properties = (from sourceProperty in source.GetType().GetProperties()
                             from ctorParam in constructor.GetParameters()
                             where sourceProperty.Name.Equals(ctorParam.Name, StringComparison.CurrentCultureIgnoreCase) &&
                                   sourceProperty.PropertyType == ctorParam.ParameterType
                             select sourceProperty.GetValue(source, null)).Cast<object>().ToArray(); 

            var activated = constructor.Invoke(properties);

            return (T) activated;
        }
    }
}