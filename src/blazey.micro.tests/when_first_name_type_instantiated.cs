using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Blazey.Micro.Tests
{
    [TestFixture]
    public class when_first_name_type_instantiated
    {
        [Test]
        public void should_invoke_ctor_with_first_name_ctor()
        {
            Assert.DoesNotThrow(() => new FirstName("Edward"));
        }
    }

    public class when_first_name_is_created_from_anemic_type : context_specification
    {
        private FirstName _firstName;
        private ModelActivator _modelActivator;
        private AnemicType _anemicType;

        protected override void Arrange()
        {
            _modelActivator = new ModelActivator();
            _anemicType = new AnemicType {FirstName = "Edward"};
        }

        protected override void Act()
        {
            _firstName = _modelActivator.Activate<FirstName>(_anemicType);
        }

        [Test]
        public void should_create_first_name()
        {
            Assert.That(_firstName.ToString(), Is.EqualTo("Edward"));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(Exception, Is.Null);
        }

        [Test]
        public void should_invoke_greediest_ctor()
        {
            Assert.That(_firstName.GeediestCtorWasCalled(), Is.True);
        }
    }

    public class AnemicType
    {
        public string FirstName { get; set; }
    }

    internal class ModelActivator
    {
        public T Activate<T>(object source)
        {
            var toActivateType = typeof (T);
            //order by scope, then length
            var constructor = toActivateType.GetConstructors(
                BindingFlags.NonPublic |
                BindingFlags.CreateInstance |
                BindingFlags.Instance).OrderByDescending(ctor => ctor.GetParameters().Length).FirstOrDefault();

            if(null == constructor) throw new InvalidOperationException("No accessible constructor");

            var activated = constructor.Invoke(new object[] {((AnemicType) source).FirstName});

            return (T) activated;
        }
    }
}