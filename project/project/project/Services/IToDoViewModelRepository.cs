using System.Collections.Generic;

namespace project.Services
{
    public interface IToDoViewModelRepository<T>
	{
		IEnumerable<T> Get();
		void Save(T item);
	}
}