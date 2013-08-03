using System;
using NUnit.Framework;

namespace Blazey.Micro.Tests
{
	[TestFixture()]
	public class when_first_name_type_instantiated
	{
		[Test()]
		public void should_invoke_ctor_with_first_name_ctor ()
		{
			Assert.DoesNotThrow(()=> new  FirstName ("Edward"));
		}
	}

	[TestFixture]
	public abstract class context_spec{

		[SetUp]
		public void SetUp(){
		}

		protected Exception Exception { get; private set; }

		protected abstract void Arrange();

		protected SUT Act<SUT>(Func<SUT> act){
			try
			{
				return act();
			}
			catch (Exception exception)
			{
				Exception = exception;
			}

			return default(SUT);
		}
	}
}

