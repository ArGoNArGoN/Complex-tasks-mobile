using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace project.Services.Entitys
{
	internal class ToDoDataBaseContext
		: BaseDataBaseContext
	{
		public ToDoDataBaseContext(SQLiteConnection connection)
			: base(connection) 
		{
			CheckTable();
		}

		private void CheckTable()
        {
            try
            {
				// connection.DropTable<ToDoEntity>();
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
					Log.Warning("INFO", "Заполнение таблицы \"ToDo\"..");

					Create(new ToDoEntity() 
					{
						Status = 1,
						Title = "CRUD",
						Count = 1,
						EndTime = new DateTime(2022, 4, 4, 11, 45, 0),
						Description = "Написать CRUD",
					});
					Create(new ToDoEntity()
					{
						Status = 1,
						Title = "Брошюры",
						Count = 120,
						EndTime = DateTime.Now + new TimeSpan(0, 3, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
					});

					Create(new ToDoEntity()
					{
						Status = 0,
						Title = "Стенды",
						Count = 3,
						EndTime = DateTime.Now + new TimeSpan(0, 3, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
					});
					Create(new ToDoEntity()
					{
						Status = 0,
						Title = "Крепежи",
						Count = 132,
						EndTime = DateTime.Now + new TimeSpan(3, 10, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
					});
					Create(new ToDoEntity()
					{
						Status = 0,
						Title = "Рамки",
						Count = 100,
						EndTime = DateTime.Now + new TimeSpan(1, 3, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
					});

					Log.Warning("INFO", "Таблица \"ToDo\" Была заполнена.");
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

			connection.Insert(entity);
		}
		public void Update(ToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			connection.Update(entity);
		}
		public void Delete(ToDoEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			connection.Delete<ToDoEntity>(entity);
		}
		public ToDoEntity Select(Int32 identity)
		{
			return connection.Get<ToDoEntity>(identity);
		}
		public IEnumerable<ToDoEntity> Select()
		{
			return connection.Table<ToDoEntity>();
		}
	}
}
