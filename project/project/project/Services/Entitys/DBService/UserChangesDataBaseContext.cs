#define IS_NOT_DEBUG
/// #define DROP_DATABASE

using SQLite;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms.Internals;

namespace project.Services.Entitys.DBService
{
	public class UserChangesDataBaseContext
		: BaseDataBaseContext, ICRUDAsync<UserChangesEntity>
	{
		private Object obj = new Object();

		public UserChangesDataBaseContext(SQLiteConnection connection) 
			: base(connection)
		{
			CheckTable();
		}

		private void CheckTable()
		{
			try
			{
#if !IS_NOT_DEBUG || DROP_DATABASE
				connection.DropTable<UserChangesEntity>();
#endif
				connection.Table<UserChangesEntity>().ToList();
			}
			catch (Exception ex)
			{
				Log.Warning("WARR", "Таблица \"UserChangesEntity\" не существовала или в ней ошибка..");
				Log.Warning("WARR", ex.Message);
				Log.Warning("INFO", "Таблица \"UserChangesEntity\" Попытка создания..");

				try
				{
					connection.CreateTable<UserChangesEntity>();
					Log.Warning("INFO", "Таблица \"UserChangesEntity\" Была создана.");
				}
				catch (Exception e)
				{
					Log.Warning("ERROR", e.Message);
					throw;
				}
			}
		}

		public async Task CreateAsync(UserChangesEntity entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));
		 	
			await Task.Run(() => 
			{
				lock (obj)
                {
					this.connection.Insert(entity);
                }
			});
		}

		public async Task DeleteAsync(UserChangesEntity entity)
		{
			await Task.Run(() =>
			{
				lock (obj)
				{
					this.connection.Delete<UserChangesEntity>(entity.Identity);
				}
			});
		}

		public async Task<UserChangesEntity> ReadAsync(int identity)
		{
			return await Task.Run(() =>
			{
				lock (obj)
				{
					return this.connection.Get<UserChangesEntity>(identity);
				}
			});
		}

		public async Task<IEnumerable<UserChangesEntity>> ReadAsync()
		{
			return await Task.Run(() =>
			{
				lock (obj)
				{
					return this.connection.Table<UserChangesEntity>().OrderBy(x => x.DateCreate);
				}
			});
		}

		public async Task UpdateAsync(UserChangesEntity entity)
		{
			await Task.Run(() =>
			{
				lock (obj)
				{
					this.connection.Update(entity);
				}
			});
		}
	}
}
