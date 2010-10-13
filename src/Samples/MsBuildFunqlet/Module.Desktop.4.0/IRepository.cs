
namespace Module
{
	public interface IRepository<T>
	{
		bool Delete(int id);
		T Read(int id);
		bool Save(T value);
	}
}
