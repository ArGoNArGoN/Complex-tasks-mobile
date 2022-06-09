#define IS_NOT_DEBUG
/// #define DROP_DATABASE

using SQLite;

using System;
using System.Collections.Generic;
using System.Threading;

using Xamarin.Forms.Internals;

namespace project.Services.Entitys.DBService
{
    public class UserDataBaseContext
        : BaseDataBaseContext, ICRUD<UserEntity>
    {
        private readonly Mutex mutexObj = new Mutex();

        public UserDataBaseContext(SQLiteConnection connection)
            : base(connection)
        {
            CheckTable();
        }

		private void CheckTable()
		{
			try
			{
#if !IS_NOT_DEBUG || DROP_DATABASE
				connection.DropTable<UserEntity>();
#endif
                connection.Table<UserEntity>().ToList();
			}
			catch (Exception ex)
			{
				Log.Warning("WARR", "Таблица \"User\" не существовала или в ней ошибка..");
				Log.Warning("WARR", ex.Message);
				Log.Warning("INFO", "Таблица \"User\" Попытка создания..");

				try
				{
					connection.CreateTable<UserEntity>();
					Log.Warning("INFO", "Таблица \"User\" Была создана.");
				}
				catch (Exception e)
				{
					Log.Warning("ERROR", e.Message);
					throw;
				}
			}
		}

		public void Create(UserEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            mutexObj.WaitOne();

            connection.Insert(entity);

            mutexObj.ReleaseMutex();
        }

        public void Delete(UserEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            mutexObj.WaitOne();

            connection.Delete<UserEntity>(entity);

            mutexObj.ReleaseMutex();
        }

        public UserEntity Read(int identity)
        {
            mutexObj.WaitOne();

            var list = connection.Get<UserEntity>(identity);

            mutexObj.ReleaseMutex();

            return list;
        }

        public IEnumerable<UserEntity> Read()
        {
            mutexObj.WaitOne();

            var list = connection.Table<UserEntity>();

            mutexObj.ReleaseMutex();

            return list;
        }

        public void Update(UserEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            mutexObj.WaitOne();

            connection.Update(entity);

            mutexObj.ReleaseMutex();
        }
    }
}
