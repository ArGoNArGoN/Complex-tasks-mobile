using System;

namespace project.Models.ToDo
{
	/// <summary>
	/// Базовая модель задачи
	/// </summary>
	public abstract class BaseToDoModel
		: BaseModel
	{
		private Int32 id = 0;
		private String title = "";
		private String description;
		private Int32 count;
		private DateTime endDate;
		private String creator;
		private String executor;

		/// <summary>
		/// Состояние задачи
		/// </summary>
		public IStateToDo State { get; protected set; }

		protected BaseToDoModel(IStateToDo state)
		{
			this.State = state 
				?? throw new ArgumentNullException(nameof(state));
		}

		/// <summary>
		/// Идентификатор
		/// </summary>
		public Int32 Identity 
		{
			get => id;
			set => id = value > 0 ? value
				: throw new ArgumentException("value < 0");
		}
		/// <summary>
		/// Короткое название
		/// </summary>
		public virtual String Title
		{
			get { return title; }
			set { title = value ?? ""; OnPropertyChanged(nameof(Title)); }
		}
		/// <summary>
		/// Количество продукции
		/// </summary>
		public virtual Int32 Count
		{
			get { return count; }
			set { count = value; OnPropertyChanged(nameof(Count)); }
		}
		/// <summary>
		/// Срок, до которого нужно выполнить данную задачу
		/// </summary>
		public virtual DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; OnPropertyChanged(nameof(endDate)); }
		}
		public virtual String Description 
		{
			get => description;
			set { description = value; OnPropertyChanged(nameof(Description)); } 
		}
		public virtual String Creator
		{
			get => creator;
			set { creator = value; OnPropertyChanged(nameof(Creator)); }
		}
		public virtual String Executor
		{
			get => executor;
			set { executor = value; OnPropertyChanged(nameof(Executor)); }
		}

		public abstract String Commit();
		public abstract String RollBack();
	}
}
