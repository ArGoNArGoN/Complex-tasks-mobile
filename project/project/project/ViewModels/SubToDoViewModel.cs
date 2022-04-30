using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
	/// <summary>
	/// Не используй, слишком сложно. VM для дополнительной задачи
	/// </summary>
	public class SubToDoViewModel
		: BaseSubToDoViewModel
	{
		/// <summary>
		/// Конструирует VM с subTo
		/// </summary>
		/// <param name="subTo">Дополнительная задача. Не может быть null</param>
		public SubToDoViewModel(SubModel subTo)
			: base(subTo) { }

		/// <summary>
		/// Название задачи
		/// </summary>
		public String Title
		{
			get { return Model.Title; }
			set
			{
				Model.Title = value;
				OnPropertyChanged(nameof(Title));
			}
		}
		/// <summary>
		/// Статус
		/// </summary>
		public String Status
		{
			get { return Model.State.Value; }
			set
			{
				OnPropertyChanged(nameof(Status));
			}
		}

		public Boolean IsChecked
		{
			get => !(Model.State is PendingSubState);
			set
			{
				OnPropertyChanged(nameof(IsChecked));
			}
		}

		public ICommand OnTapped => new Command<Boolean>((value) =>
		{
			if (value)
				Model.RollBack();

			else
				Model.Commit();

			IsChecked = value;
		});
	}
}