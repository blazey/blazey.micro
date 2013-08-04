using Blazey.Micro.Tests.doubles;
using NUnit.Framework;
using blazey.micro;

namespace Blazey.Micro.Tests
{
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
}