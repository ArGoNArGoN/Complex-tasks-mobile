using project.Models.ToDo;
using System;
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
		private SubModel subTo;

		/// <summary>
		/// Дополнительная задача
		/// </summary>
		public SubModel SubModel
		{
			get => subTo;
			protected set
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
		public SubToDoViewModel(SubModel subTo)
		{
			SubModel = subTo ??
				throw new ArgumentNullException(nameof(subTo));
		}

		/// <summary>
		/// Название задачи
		/// </summary>
		public String Title
		{
			get { return SubModel.Title; }
			set
			{
				SubModel.Title = value;
				OnPropertyChanged(nameof(Title));
			}
		}
		/// <summary>
		/// Статус
		/// </summary>
		public String Status
		{
			get { return SubModel.State.Value; }
			set
			{
				OnPropertyChanged(nameof(Status));
			}
		}

		public ICommand OnTapped => new Command((ob) =>
		{
			if (ob is Boolean)
				throw new InvalidCastException(nameof(ob) + "is not Boolean");

			if ((Boolean)ob)
				SubModel.RollBack();

			else
				SubModel.Commit();
		});
	}
}