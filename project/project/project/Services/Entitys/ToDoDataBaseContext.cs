using Xamarin.Forms.Internals;

using SQLite;

using System;
using System.Collections.Generic;
using System.Threading;

namespace project.Services.Entitys
{
    public class ToDoDataBaseContext
		: BaseDataBaseContext, ICRUD<ToDoEntity>
	{
		private Mutex mutexObj = new Mutex();

		public ToDoDataBaseContext(SQLiteConnection connection)
			: base(connection) 
		{
			CheckTable();
		}

		private void CheckTable()
        {
            try
            {
				connection.DropTable<ToDoEntity>();
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
						Title = "CRUD",
						Count = 1,
						EndTime = new DateTime(2022, 4, 4, 11, 45, 0),
						Description = "Написать CRUD",
					    Creator = "Thomas Miller",
						Executor = "Luis Greene",
						State = "Активная",
						TypeTask = "ToDoSubs",
					});
					Create(new ToDoEntity()
					{
						Title = "Брошюры",
						Count = 120,
						EndTime = DateTime.Now + new TimeSpan(0, 3, 0, 0),
						Creator = "Thomas Miller",
						Executor = "Luis Greene",
						State = "Активная",
						TypeTask = "ToDo",
					});

					Create(new ToDoEntity()
					{
						Title = "Стенды",
						Count = 3,
						EndTime = DateTime.Now + new TimeSpan(0, 3, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
						Creator = "Thomas Miller",
						Executor = "Luis Greene",
						State = "Ожидающая",
						TypeTask = "ToDo",
					});
					Create(new ToDoEntity()
					{
						Title = "Крепежи",
						Count = 132,
						EndTime = DateTime.Now + new TimeSpan(3, 10, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
						Creator = "Bob",
						Executor = "Luis Greene",
						State = "Ожидающая",
						TypeTask = "ToDo",
					});
					Create(new ToDoEntity()
					{
						Title = "Рамки",
						Count = 100,
						EndTime = DateTime.Now + new TimeSpan(1, 3, 0, 0),
						Description = "Распечатать в стандартном виде. Посмотри, есть ли на складе серая бумага (хватит ли ее). Если нет, то прокинь событие. \nОсновные требования:\n- Обложка должна быть КАРТОННАЯ.\n- Брака не должно быть.За этим нужно следить.\n- Основные требования в документе",
						Creator = "Bob",
						Executor = "Luis Greene",
						State = "Ожидающая",
						TypeTask = "ToDo",
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
