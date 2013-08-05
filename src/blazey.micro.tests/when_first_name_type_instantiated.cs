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
            Assert.DoesNotThrow(() => new Name("Edward", "Blackburn"));
        }
    }
}