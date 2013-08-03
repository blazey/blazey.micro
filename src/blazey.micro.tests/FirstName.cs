using System;

namespace Blazey.Micro
{
	public class FirstName
	{
		public FirstName(string firstName)
		{
			if (firstName == null)
				throw new ArgumentNullException ("firstName");
		}
	}
}

