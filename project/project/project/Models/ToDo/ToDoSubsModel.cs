using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Models.ToDo
{
	public class ToDoSubsModel
		: BaseToDoModel
	{
		public ToDoSubsModel(IStateToDo state) 
			: this(state, new List<SubModel>()) { }
		public ToDoSubsModel(IStateToDo state, IEnumerable<SubModel> subToDos)
			: base(state)
		{
			SubToDos = subToDos ?? new List<SubModel>();
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
			=> State.Commit(this, (state) => State = state);
		public override String RollBack()
			=> State.RollBack(this, (state) => State = state);
	}
}