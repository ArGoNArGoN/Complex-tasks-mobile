using project.Models;
using System;
using System.Linq;

namespace project.ViewModels
{
    /// <summary>
    /// Связывет отображение Модели ToDo и ContentView
    /// </summary>
    public class ToDoViewModel<T>
		: BaseViewModel
		where T : ToDoModel, new()
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
		public virtual TimeSpan EndDate
		{
			get { return ToDo.EndDate - DateTime.Now;  }
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
		/// Создает пустой объект
		/// </summary>
		public ToDoViewModel(T toDo)
			: this()
		{
			ToDo = toDo ?? new T();
		}

		/// <summary>
		/// true - подзадач нет, false - подзадачи есть
		/// </summary>
		public Boolean IsEmptySubToDos { get => this.ToDo.SubToDosIsEmpty; }

		public virtual Int32 GetCountCompletedSubToDos { get => this.ToDo.SubToDos.OfType<CompletedSubToDo>().Count(); }
		public virtual Int32 GetCountActiveSubToDos { get => this.ToDo.SubToDos.OfType<ActiveSubToDo>().Count(); }
		public virtual Int32 GetAllCountSubToDos { get => this.ToDo.SubToDos.Count(); }

		/// <summary>
		/// Ищет задачу по id и присваивает поля
		/// </summary>
		/// <param name="id">Идентификатор задачи</param>
		protected void SetNewToDo(Int32 id)
        {
			throw new NotImplementedException();
        }
		public StatusToDo GetStatus
		{
			get => ToDo.EndDate < DateTime.Now ? StatusToDo.Overdue
				: ToDo.EndDate - DateTime.Now < new TimeSpan(1, 0, 0, 0) ? StatusToDo.Urgently
				: ToDo.EndDate - DateTime.Now < new TimeSpan(2, 0, 0, 0) ? StatusToDo.Priority
				: StatusToDo.None;
		}
	}
}
