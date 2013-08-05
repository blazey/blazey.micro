using System;
using NUnit.Framework;
using blazey.micro;

namespace Blazey.Micro.Tests
{
    public class when_model_has_no_ctor : context_specification
    {
        private ModelActivator _modelActivator;

        protected override void Arrange()
        {
            _modelActivator = new ModelActivator();
        }

        protected override void Act()
        {
            _modelActivator.Activate<SimplestType>(new object());
        }

        [Test]
        public void should_throw_invalid_operation_exception()
        {
            Assert.That(Exception, Is.InstanceOf<InvalidOperationException>());
        }

        private class SimplestType
        {
        }
    }
}