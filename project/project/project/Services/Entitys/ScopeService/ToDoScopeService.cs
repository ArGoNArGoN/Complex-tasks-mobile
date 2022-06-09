using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Services.Entitys.ScopeService
{
	public sealed class ToDoScopeService
		: ICRUD<ToDoEntity>
	{
		private readonly ICRUD<ToDoEntity> _db;
		private readonly ICRUDAsync<UserChangesEntity> _local_save_db;
		private readonly ICRUDAsync<ToDoEntity> _service;
		private object lockObj = new object();
		private const double timerefresh = 2D;
		private Boolean islockservice;
		private IEnumerable<ToDoEntity> lazyEnumerable = new List<ToDoEntity>();
        private ToDoEntity lazyItem;

        public ToDoScopeService(ICRUD<ToDoEntity> db, ICRUDAsync<ToDoEntity> service, ICRUDAsync<UserChangesEntity> local_save_db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
			this._service = service ?? throw new ArgumentNullException(nameof(service));
			this._local_save_db = local_save_db ?? throw new ArgumentNullException(nameof(local_save_db));
		}

        public void Create(ToDoEntity entity)
		{
			_db.Create(entity);
		}

		public void Delete(ToDoEntity entity)
		{
			if (entity is null)
				return;

			_db.Delete(entity);
		}

		public ToDoEntity Read(int identity)
		{
			lock (lockObj)
			{
				if (islockservice)
					return lazyItem;

				var item = lazyItem = _service.ReadAsync(identity).Result;

				lockservice();

				this.SaveDB(item);

				return item;
			}
		}

		private async void SaveDB(ToDoEntity entitiy)
		{
			await Task.Run(() =>
			{
				_db.Update(entitiy);
			});
		}
		private async void SaveDB(IEnumerable<ToDoEntity> entities)
        {
			await Task.Run(() =>
			{
				foreach (var item in entities)
                {
                    _db.Update(item);
                }
            });
        }

		public IEnumerable<ToDoEntity> Read()
		{
			lock (lockObj)
			{
				if (islockservice)
					return lazyEnumerable;

				var collection = lazyEnumerable = _service.ReadAsync().Result;

				lockservice();

				this.SaveDB(collection);

				return collection;
			}
		}

		private async void lockservice()
        {
			await Task.Run(() => { islockservice = true; Task.Delay((Int32)(timerefresh * 1000)); islockservice = false; });
        }

		public async void Update(ToDoEntity entity)
		{
			await _service.UpdateAsync(entity);

			var result = await _service.ReadAsync(entity.Identity);

			this.SaveDB(result);
		}
	}
}
