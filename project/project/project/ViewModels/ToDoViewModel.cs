using project.Models;
using project.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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
		public virtual ObservableCollection<SubToDoViewModel> SubToDos { get; } = new ObservableCollection<SubToDoViewModel>();

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
			SubToDos = new ObservableCollection<SubToDoViewModel>(ToDo.SubToDos.Select(x => new SubToDoViewModel(x)));
			SubToDos.ToList().ForEach(x => x.StatusEdit += OnStatusChanged);
		}

		private void OnStatusChanged(Object sender, EventArgs e)
		{
			var vm = sender as SubToDoViewModel;

			if (vm is null)
				throw new InvalidCastException("sender is not SubToDoViewModel");

			SubToDoModel subToDo = null;

			/// тут какая-то логика с бд НАЧАЛАСЬ
			if (vm.Status)
				subToDo = new ActiveSubToDo(vm.SubTo);

			else
				subToDo = new CompletedSubToDo(vm.SubTo);

			Task.Run(() => DependencyService.Get<BaseToDoRepository>().UpdateSubToDo(subToDo, ToDo.Identity));

			/// тут какая-то логика с бд ЗАКОНЧИЛАСЬ

			vm.SubTo = subToDo;

			OnUpdateView();
		}

		/// <summary>
		/// true - подзадач нет, false - подзадачи есть
		/// </summary>
		public Boolean IsEmptySubToDos { get => this.ToDo.SubToDosIsEmpty; }

		public virtual Int32 GetCountCompletedSubToDos { get => this.SubToDos.Count(x => x.SubTo is CompletedSubToDo); }
		public virtual Int32 GetCountActiveSubToDos { get => this.SubToDos.Count(x => x.SubTo is ActiveSubToDo); }
		public virtual Int32 GetAllCountSubToDos { get => this.SubToDos.Count(); }

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

		protected virtual void OnUpdateView()
        {
			OnPropertyChanged(nameof(GetCountCompletedSubToDos));
			OnPropertyChanged(nameof(GetCountActiveSubToDos));
			OnPropertyChanged(nameof(GetAllCountSubToDos));
		}
	}
}
