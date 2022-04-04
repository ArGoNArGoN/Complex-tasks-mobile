using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace project.Services.Entitys
{
    internal class SubToDoDataBaseContext
		: BaseDataBaseContext
	{
		public SubToDoDataBaseContext(SQLiteConnection connection) 
			: base(connection)
		{
			CheckTable();
		}
		private void CheckTable()
        {
            try
			{
				// connection.DropTable<SubToDoEntity>();
				connection.Table<SubToDoEntity>().ToList();
			}
            catch (Exception ex)
			{
				Log.Warning("WARR", "Таблица \"SubToDo\" не существовала или в ней ошибка..");
				Log.Warning("WARR", ex.Message);
				Log.Warning("INFO", "Таблица \"SubToDo\" Попытка создания..");
				
				try
				{
					connection.CreateTable<SubToDoEntity>();
					Log.Warning("INFO", "Таблица \"SubToDo\" Была создана.");
					Log.Warning("INFO", "Заполнение таблицы \"SubToDo\"..");

					Create(new SubToDoEntity() { ToDoIdentity = 1, Status = 0, Title = "Create" });
					Create(new SubToDoEntity() { ToDoIdentity = 1, Status = 0, Title = "Update" });
					Create(new SubToDoEntity() { ToDoIdentity = 1, Status = 0, Title = "Delete" });
					Create(new SubToDoEntity() { ToDoIdentity = 1, Status = 1, Title = "Select" });
				}
				catch (Exception e)
				{
					Log.Warning("ERROR", e.Message);
					throw;
				}
			}
		}
		public void Create(SubToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			connection.Insert(entity);
		}
		public void Update(SubToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			connection.Update(entity);
		}
		public void Delete(SubToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			connection.Delete<ToDoEntity>(entity);
		}
		public ToDoEntity Select(Int32 identity)
		{
			return connection.Get<ToDoEntity>(identity);
		}
		public IEnumerable<SubToDoEntity> Select()
		{
			return connection.Table<SubToDoEntity>();
		}

		public IEnumerable<SubToDoEntity> SelectWhere(Int32 identity)
        {
			var entitys = connection.Table<SubToDoEntity>();

			if (entitys.Count() == 0)
				return new List<SubToDoEntity>();

			return entitys.Where(x => x.ToDoIdentity == identity).ToList();
		}
	}
}
