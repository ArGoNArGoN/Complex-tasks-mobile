using project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
	/// <summary>
	/// Не используй, слишком сложно. VM для дополнительной задачи
	/// </summary>
	public class SubToDoViewModel
		: BaseViewModel
	{
		private SubToDo subTo;

		/// <summary>
		/// Событие изменения статуса
		/// </summary>
		public event Action<Object, EventArgs> StatusEdit;

		/// <summary>
		/// Дополнительная задача
		/// </summary>
		public SubToDo SubTo 
		{ 
			get => subTo;
			set
			{
				subTo = value ??
					throw new NullReferenceException(nameof(value));

				OnPropertyChanged(nameof(Title));
				OnPropertyChanged(nameof(Status));
			}
		}
		/// <summary>
		/// Конструирует VM с subTo
		/// </summary>
		/// <param name="subTo">Дополнительная задача. Не может быть null</param>
		public SubToDoViewModel(SubToDo subTo)
        {
            SubTo = subTo ??
				throw new ArgumentNullException(nameof(subTo));
        }

        /// <summary>
        /// Название задачи
        /// </summary>
        public String Title
		{
			get { return SubTo.Title; }
			set
			{
				SubTo.Title = value;
				OnPropertyChanged(nameof(Title));
			}
		}
		/// <summary>
		/// Статус
		/// </summary>
		public Boolean Status
		{
			get { return SubTo.Status; }
			set
			{
				if (value != Status)
					StatusEdit?.Invoke(this, new EventArgs());

				OnPropertyChanged(nameof(Status));
			}
		}

		public ICommand OnTapped { get => new Command((_) => Status = !Status); }
	}
}
