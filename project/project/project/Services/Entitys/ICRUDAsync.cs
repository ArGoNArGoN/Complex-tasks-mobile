using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Services.Entitys
{
    public interface ICRUDAsync<T>
		where T : BaseEntity
	{
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<T> ReadAsync(Int32 identity);

		Task<IEnumerable<T>> ReadAsync();
	}
}
