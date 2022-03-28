using System;
using System.Collections.Generic;
using System.Text;

namespace project.Models
{
	public class PendingToDoModel
		: ToDoModel
	{
		/// <summary>
		/// Инициализирует Ожидающую задачу.
		/// </summary>
		public PendingToDoModel()
			: base(new List<SubToDo>()) { }
		/// <summary>
		/// Инициализирует Ожидающую задачу с подзадачами.
		/// </summary>
		/// <param name="subToDos">Подзадачи</param>
		public PendingToDoModel(IEnumerable<SubToDo> subToDos)
			: base(subToDos) { }
	}
}
