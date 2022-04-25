using project.Models;
using System.Collections.Generic;

namespace project.Services
{
    public interface IRepository<T, V>
		where T : IAggregateRoot
	{
		T Get(V id);
		IEnumerable<T> Get();
		void Save(T item);
		void Delete(V id);
	}
}
