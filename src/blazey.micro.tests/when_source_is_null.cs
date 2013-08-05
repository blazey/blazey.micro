using System;
using NUnit.Framework;
using blazey.micro;

namespace Blazey.Micro.Tests
{
    public class when_source_is_null : context_specification
    {
        private ModelActivator _modelActivator;

        protected override void Arrange()
        {
            _modelActivator = new ModelActivator();
        }

        protected override void Act()
        {
            _modelActivator.Activate<SimpleType>(null);
        }


        [Test]
        public void should_throw_invalid_operation_exception()
        {
            Assert.That(Exception, Is.InstanceOf<ArgumentNullException>());
        }

        private class SimpleType
        {
        }
    }
}