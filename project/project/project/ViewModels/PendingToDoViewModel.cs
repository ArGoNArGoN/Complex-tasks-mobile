using project.Models;
using System;

namespace project.ViewModels
{
	public class PendingToDoViewModel
		: BaseToDoDetailsViewModel<PendingToDoModel>
	{
		public PendingToDoViewModel()
			: this(new PendingToDoModel()) { }
		public PendingToDoViewModel(PendingToDoModel toDo)
			: base(toDo)
		{
			this.TitleAction = "Приступить";
		}

		/// <summary>
		/// TODO: Сделать проверку количества активных задач.
		/// Пользователь не может взять задач больше 2 или 3.
		/// </summary>
		public override bool ItsPossibleCommit => base.ItsPossibleCommit;

		public override BaseViewModel Commiit()
		{
			if (!ItsPossibleCommit)
				throw new Exception("Ошибка при проведении Ожидающей задачи. Action: Commiit");

			/// тут запрос к сервису

			return new ActiveToDoViewModel(new ActiveToDoModel(this.ToDo.SubToDos) { Title = this.ToDo.Title, Count = this.ToDo.Count, EndDate = this.ToDo.EndDate });
		}
		public override BaseViewModel Rollback()
		{
			throw new Exception("Ошибка при проведении Ожидающей задачи. Action: Rollback");
		}
	}
}