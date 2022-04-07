using project.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace project.Models
{
    public abstract class BaseToDosModel<T>
		: BaseModel
		where T : BaseToDoModel
	{
		private IRepository<T, Int32> Repository;

		private ObservableCollection<T> collectionToDos;

        protected BaseToDosModel()
        {
			collectionToDos = new ObservableCollection<T>();
		}

        /// <summary>
        /// Коллекция задач. Переприсваивать только в крайних случаях.
        /// </summary>
        public ObservableCollection<T> CollectionToDos
		{
			get => collectionToDos;
			private set
			{
				collectionToDos = value
					?? throw new ArgumentNullException(nameof(value));

				Log.Warning("INFO", "Коллекция задач была обновлена");

				OnPropertyChanged(nameof(CountItmes));
			}
		}

		/// <summary>
		/// Возвращает количество задач.
		/// </summary>
		/// <returns></returns>
		public Int32 CountItmes { get => CollectionToDos.Count; }

		/// <summary>
		/// Загружает задачи.
		/// </summary>
		public async void LoadItems()
        {
			CollectionToDos.Clear();

            try
            {
				var collection = await Task.Run(() => Repository.Get());

				foreach (var item in collection)
				{
					CollectionToDos.Add(item);
				}
            }
            catch (Exception ex)
            {
				Log.Warning("ERROR", ex.ToString());
                throw;
            }

			OnPropertyChanged(nameof(CountItmes));
        }
		/// <summary>
		/// Обновляет задачи.
		/// </summary>
		public async void ReloadItems()
        {
			CollectionToDos.Clear();

			try
			{
				var collection = await Task.Run(() => Repository.Get());

				foreach (var item in collection)
				{
					CollectionToDos.Add(item);
				}
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", ex.ToString());
				throw;
			}

			OnPropertyChanged(nameof(CountItmes));
		}

		/// <summary>
		/// Добавляет задачу в коллекцию и обновляет в Repository
		/// </summary>
		/// <param name="item">Задача</param>
		public virtual void AddItem(T item)
        {
			if (item is null)
				throw new ArgumentNullException(nameof(item));

            try
            {
				Repository.Save(item);
            }
            catch (Exception ex)
			{
				Log.Warning("ERROR", ex.ToString());
				throw;
            }
            finally
            {
				this.ReloadItems();
            }

			OnPropertyChanged(nameof(CountItmes));
        }
		/// <summary>
		/// Удалаяет задачу из коллекции и обновляет в Repository
		/// </summary>
		/// <param name="item">Задача</param>
		public virtual void RemoveItem(T item)
		{
			if (item is null)
				throw new ArgumentNullException(nameof(item));

			try
			{
				Repository.Delete(item.Identity);
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", ex.ToString());
				throw;
			}
			finally
			{
				this.ReloadItems();
			}

			OnPropertyChanged(nameof(CountItmes));
		}
		/// <summary>
		/// Обновляет элемент в коллекции и обновляет в Repository
		/// </summary>
		/// <param name="item">Задача</param>
		public virtual void Upload(T item)
		{
			if (item is null)
				throw new ArgumentNullException(nameof(item));

			try
			{
				Repository.Save(item);
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", ex.ToString());
				throw;
			}
			finally
			{
				this.ReloadItems();
			}

			OnPropertyChanged(nameof(CountItmes));
		}
	}
}