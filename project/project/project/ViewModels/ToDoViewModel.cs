using project.Models;
using System;


namespace project.ViewModels
{
    /// <summary>
    /// Связывет отображение Модели ToDo и ContentView
    /// </summary>
    public class ToDoViewModel<T>
		: BaseViewModel
		where T : BaseToDoModel, new()
	{
		/// <summary>
		/// модель, которую необходимо отобразить
		/// </summary>
		public T ToDo { get; private set; }

		/// <summary>
		/// Короткое название 
		/// </summary>
		public virtual String Title
		{
			get { return ToDo.Title + ":"; }
			protected set { ToDo.Title = value ?? ""; OnPropertyChanged(nameof(Title)); }
		}
		/// <summary>
		/// Срок, до которого нужно выполнить данную задачу
		/// </summary>
		public virtual DateTime EndDate
		{
			get { return ToDo.EndDate; }
			protected set 
			{
				ToDo.EndDate = value;
				OnPropertyChanged(nameof(value));
			}
		}
		/// <summary>
		/// Количество продукции
		/// </summary>
		public virtual Int32 Count
        {
			get { return ToDo.Count; }
			protected set { ToDo.Count = value > 0 ? value : throw new ArgumentException("value > 0", nameof(value)); }
        }

		/// <summary>
		/// Создает пустой объект
		/// </summary>
		public ToDoViewModel()
			: base()
		{
			ToDo = new T();
		}

		/// <summary>
		/// Ищет задачу по id и присваивает поля
		/// </summary>
		/// <param name="id">Идентификатор задачи</param>
		protected void SetNewToDo(Int32 id)
        {
			throw new NotImplementedException();
        }
	}
}
