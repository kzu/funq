using System;

namespace Funq
{
	internal sealed class ServiceKey
	{
		public ServiceKey(Type serviceType, Type factoryType, string serviceName)
		{
			ServiceType = serviceType;
			FactoryType = factoryType;
			Name = serviceName;
		}

		public Type ServiceType { get; private set; }
		public Type FactoryType { get; private set; }
		public string Name { get; private set; }

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
				Object.Equals(null, obj2) ||
				obj1.GetType() != obj2.GetType())
				return false;

			if (Object.ReferenceEquals(obj1, obj2)) return true;

			return obj1.ServiceType == obj2.ServiceType &&
				obj1.FactoryType == obj2.FactoryType && 
				obj1.Name == obj2.Name;
		}

		public override int GetHashCode()
		{
			int hash = ServiceType.GetHashCode();
			hash ^= FactoryType.GetHashCode();
			if (Name != null)
				hash ^= Name.GetHashCode();

			return hash;
		}

		#endregion
	}
}