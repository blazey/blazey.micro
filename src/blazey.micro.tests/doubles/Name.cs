using System;

namespace Blazey.Micro.Tests.doubles
{
	internal class Name
	{
	    private readonly string _firstName;
        private readonly string _lastName;
	    private readonly int _age;
	    private readonly bool _greediestCtorWasCalled;

	    internal Name()
	    {
	        _greediestCtorWasCalled = false;
	    }

		internal Name(string firstName, string lastName, int age)
		{

		    if (null == firstName) throw new ArgumentNullException("firstName");
		    if(null == lastName) throw new ArgumentNullException("lastName");
            if (0 >= age) throw new ArgumentNullException("age");


            _firstName = firstName;
		    _lastName = lastName;
		    _age = age;
		    _greediestCtorWasCalled = true;

		}

        internal bool GeediestCtorWasCalled()
        {
           return  _greediestCtorWasCalled;
        }

	    public override string ToString()
	    {
	        return string.Join(" ", _firstName, _lastName, _age);
	    }
	}
}

