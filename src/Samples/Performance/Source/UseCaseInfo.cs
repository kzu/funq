using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Performance
{
	public class UseCaseInfo
	{
		public UseCaseInfo(UseCase useCase)
		{
			this.Name = ((DescriptionAttribute)useCase.GetType()
				.GetCustomAttributes(typeof(DescriptionAttribute), true)[0]).Description;
			this.UseCase = useCase;
		}

		public string Name { get; private set; }
		public UseCase UseCase { get; private set; }

		public static implicit operator UseCaseInfo(UseCase useCase)
		{
			return new UseCaseInfo(useCase);
		}
	}
}
