using System;
using System.Linq;
using System.Reflection;

namespace blazey.micro
{
    public class ModelActivator
    {
        public T Activate<T>(object source)
        {
            if (null == source) throw new ArgumentNullException("source");

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

            var ctorParameters = constructor.GetParameters();

            if (null == ctorParameters.FirstOrDefault())
            {
                throw new InvalidOperationException("No accessible constructor");
            }

            var properties = source.GetType().GetProperties().Select(info => Parameter.FromPropertyInfo(info, source));
            var parameters = constructor.GetParameters().Select(Parameter.FromParameterInfo);

            Func<Parameter, Parameter, bool> sameTypeIgnoreCase =
                (ctor, prop) =>
                ctor.Name.Equals(prop.Name, StringComparison.CurrentCultureIgnoreCase) &&
                ctor.Type == prop.Type;

            var matches = from prop in properties
                          from param in parameters
                          where sameTypeIgnoreCase(prop, param)
                          select prop;

            var values = matches.Select(par => par.Value).ToArray();
            var activated = constructor.Invoke(values);

            return (T) activated;
        }


    }
}