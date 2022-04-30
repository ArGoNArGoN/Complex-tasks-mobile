using project.Services.ToDoService.StateService.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Models.ToDo
{
	public class ToDoSubsModel
		: BaseToDoModel
	{
		private readonly ISaveToDoModel<ToDoSubsModel> _service;

		public ToDoSubsModel(IStateToDo state, IEnumerable<SubModel> subToDos, ISaveToDoModel<ToDoSubsModel> service)
			: base(state)
		{
			SubToDos = subToDos ?? new List<SubModel>();
			_service = service;
		}

		/// <summary>
		/// Список подзадач. 
		/// </summary>
		public IEnumerable<SubModel> SubToDos { get; }
		/// <summary>
		/// Проверяет, существуют ли подзадачи
		/// </summary>
		public Boolean SubToDosIsEmpty => SubToDos.Count() == 0;

		public override String Commit()
			=> State.Commit(this, (state) =>
			{
				State = state;
				_service.Save(this);
			});
		public override String RollBack()
			=> State.RollBack(this, (state) =>
			{
				State = state;
				_service.Save(this);
			});
	}
}