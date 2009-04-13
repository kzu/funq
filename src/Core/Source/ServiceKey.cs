using System;

namespace Funq
{
	internal sealed class ServiceKey
	{
		int hash;

		public ServiceKey(Type factoryType, string serviceName)
		{
			FactoryType = factoryType;
			Name = serviceName;

			hash = factoryType.GetHashCode();
			if (serviceName != null)
				hash ^= serviceName.GetHashCode();
		}

		public Type FactoryType;
		public string Name;

		#region Equality

		public bool Equals(ServiceKey other)
		{
			return ServiceKey.Equals(this, other);
		}

		public override bool Equals(object obj)
		{
			return ServiceKey.Equals(this, obj as ServiceKey);
		}

		public static bool Equals(ServiceKey obj1, ServiceKey obj2)
		{
			if (Object.Equals(null, obj1) ||
				Object.Equals(null, obj2))
				return false;

			if (Object.ReferenceEquals(obj1, obj2)) return true;

			return obj1.hash == obj2.hash;
		}

		public override int GetHashCode()
		{
			return hash;
		}

		#endregion
	}
}