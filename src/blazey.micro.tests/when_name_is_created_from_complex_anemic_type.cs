using Blazey.Micro.Tests.doubles;
using NUnit.Framework;
using blazey.micro;

namespace Blazey.Micro.Tests
{
    public class when_name_is_created_from_complex_anemic_type : context_specification
    {
        private Name _name;
        private ModelActivator _modelActivator;
        private AnemicType _anemicType;

        protected override void Arrange()
        {
            _modelActivator = new ModelActivator();
            _anemicType = new AnemicType { FirstName = "Edward", LastName = "Blackburn", Age = 33 };
        }

        protected override void Act()
        {
            _name = _modelActivator.Activate<Name>(_anemicType);
        }

        [Test]
        public void should_create_fulls_name()
        {
            Assert.That(_name.ToString(), Is.EqualTo("Edward Blackburn 33"));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(Exception, Is.Null);
        }

        [Test]
        public void should_invoke_greediest_ctor()
        {
            Assert.That(_name.GeediestCtorWasCalled(), Is.True);
        }
    }
}