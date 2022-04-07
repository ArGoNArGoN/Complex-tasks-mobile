using project.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace project.ViewModels
{
	public abstract class BaseToDoDetailsViewModel<T>
		: ToDoViewModel<T>, IActionToDo
		where T : ToDoModel, new()
	{
		protected BaseToDoDetailsViewModel()
			: this(new T()) { }
		protected BaseToDoDetailsViewModel(T toDo) 
			: base(toDo) 
		{
			TitlePage = $"{ToDo.Title} ID: {ToDo.Identity}";
		}

        /// <summary>
        /// Описание задачи
        /// </summary>
        public String Description
		{
			get => this.ToDo.Description;
			protected set
			{
				this.ToDo.Description = value ?? "";
				OnPropertyChanged(nameof(Description));
			}
		}
		/// <summary>
		/// Название действия
		/// </summary>
		public virtual String TitleAction { get; protected set; }
		/// <summary>
		/// true - можно перейти на следующий шаг, false - нельзя перейти на следующий шаг
		/// </summary>
		public virtual Boolean ItsPossibleCommit { get; } = true;
		/// <summary>
		/// true - можно перейти на предыдущий шаг, false - нельзя перейти на предыдущий шаг
		/// </summary>
		public virtual Boolean ItsPossibleRollback { get; } = true;

		/// <summary>
		/// Коллекция дополнительных команд
		/// </summary>
		public virtual IDictionary<String, ICommand> SubCommands { get; protected set; }

		public abstract BaseViewModel Commit();
		public abstract BaseViewModel Rollback();
	}
}
