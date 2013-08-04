using System;

namespace Blazey.Micro.Tests.doubles
{
	internal class FirstName
	{
	    private readonly string _firstName;
	    private readonly bool _greediestCtorWasCalled;

	    internal FirstName()
	    {
	        _greediestCtorWasCalled = false;
	    }

		internal FirstName(string firstName)
		{
		    _firstName = firstName;
		    if (firstName == null)
		    {
		        throw new ArgumentNullException("firstName");
		    }

		    _greediestCtorWasCalled = true;

		}

        internal bool GeediestCtorWasCalled()
        {
           return  _greediestCtorWasCalled;
        }

	    public override string ToString()
	    {
	        return _firstName;
	    }
	}
}

