using System;
using NUnit.Framework;

namespace Blazey.Micro.Tests
{
    [TestFixture]
    public abstract class context_spec{

        [SetUp]
        public void SetUp(){
            Arrange();
            try
            {
                Act();
            }
            catch (Exception exception)
            {
                Exception = exception;
            }
        }

        protected Exception Exception { get; private set; }

        protected abstract void Arrange();

        protected abstract void Act();

    
    }
}