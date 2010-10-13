using System;
using Funq;

namespace Module.Funqlet
{
	public partial class Funqlet : IFunqlet
	{
		partial void DoConfigure(Container container)
		{
			// Provide custom registrations here if needed.
		}
	}
}
