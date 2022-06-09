#define IS_NOT_DEBUG
#define DROP_DATABASE

using Xamarin.Forms.Internals;

using SQLite;

using System;
using System.Collections.Generic;
using System.Threading;

namespace project.Services.Entitys.DBService
{
    public class ToDoDataBaseContext
		: BaseDataBaseContext, ICRUD<ToDoEntity>
	{
		private readonly Mutex mutexObj = new Mutex();

		public ToDoDataBaseContext(SQLiteConnection connection)
			: base(connection) 
		{
			CheckTable();
		}

		private void CheckTable()
        {
            try
			{
#if !IS_NOT_DEBUG || DROP_DATABASE
				connection.DropTable<ToDoEntity>();
#endif
				connection.Table<ToDoEntity>().ToList();
			}
            catch (Exception ex)
            {
				Log.Warning("WARR", "Таблица \"ToDo\" не существовала или в ней ошибка..");
				Log.Warning("WARR", ex.Message);
				Log.Warning("INFO", "Таблица \"ToDo\" Попытка создания..");

                try
                {
					connection.CreateTable<ToDoEntity>();
					Log.Warning("INFO", "Таблица \"ToDo\" Была создана.");
				}
				catch (Exception e)
				{
					Log.Warning("ERROR", e.Message);
					throw;
				}
			}
        }

		public void Create(ToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			mutexObj.WaitOne();

			connection.Insert(entity);

			mutexObj.ReleaseMutex();
		}
		public void Update(ToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			mutexObj.WaitOne();

			connection.Update(entity);

			mutexObj.ReleaseMutex();
		}
		public void Delete(ToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			mutexObj.WaitOne();
			
			connection.Delete<ToDoEntity>(entity);

			mutexObj.ReleaseMutex();
		}
		public ToDoEntity Read(Int32 identity)
		{
			mutexObj.WaitOne();

			var list = connection.Get<ToDoEntity>(identity);

			mutexObj.ReleaseMutex();

			return list;
		}

        public IEnumerable<ToDoEntity> Read()
		{
			mutexObj.WaitOne();

			var list = connection.Table<ToDoEntity>();

			mutexObj.ReleaseMutex();

			return list;
		}
    }
}
