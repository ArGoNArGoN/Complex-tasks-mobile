using System;
using System.Collections.Generic;

namespace project.Services.Entitys
{
    public interface ICRUD<T>
    {
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		T Read(Int32 identity);

		IEnumerable<T> Read();
	}
}
