using project.Models;
using System;
using System.Windows.Input;

namespace project.ViewModels
{
    public class ActiveToDoViewModel
		: BaseToDoDetailsViewModel<ActiveToDoModel>
	{
		public ActiveToDoViewModel()
			: this (new ActiveToDoModel()) { }
		public ActiveToDoViewModel(ActiveToDoModel toDo)
			: base (toDo) 
		{
			TitleAction = "Завершить";
		}

        public override Boolean ItsPossibleCommit
			=> IsEmptySubToDos || (this.GetCountCompletedSubToDos == this.GetAllCountSubToDos);
        public override Boolean ItsPossibleRollback 
			=> IsEmptySubToDos || this.GetCountCompletedSubToDos == 0;

        public override BaseViewModel Commiit()
		{
			if (!ItsPossibleCommit)
				throw new Exception("Ошибка при проведении Активной задачи. Action: Commiit");

			throw new NotImplementedException("Не реализовано!");
		}
		public override BaseViewModel Rollback()
		{
			if (!ItsPossibleRollback)
				throw new Exception("Ошибка при проведении Активной задачи. Action: Rollback");

			/// здесь должен быть запрос к сервису;

			/// естественно переделать
			return new PendingToDoViewModel(new PendingToDoModel(this.ToDo.SubToDos) { Title = this.ToDo.Title, Count = this.ToDo.Count, EndDate = this.ToDo.EndDate });
		}
    }
}
