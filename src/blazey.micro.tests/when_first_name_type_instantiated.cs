using Blazey.Micro.Tests.doubles;
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

    public class when_model_has_no_ctor : context_specification
    {
        protected override void Arrange()
        {
            throw new System.NotImplementedException();
        }

        protected override void Act()
        {
            throw new System.NotImplementedException();
        }

        [Test]
        public void should_throw_invalid_operation_exception()
        {
            
        }
    }
}