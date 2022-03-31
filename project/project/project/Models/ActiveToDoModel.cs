using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace project.Models
{
	/// <summary>
	/// Задача, которую пользователь пометил, как выполняющуюся.
	/// </summary>
	public class ActiveToDoModel
		: ToDoModel
	{
        /// <summary>
        /// Инициализирует Активную задачу.
        /// </summary>
        public ActiveToDoModel()
			: base(new List<SubToDo>()) { }
		/// <summary>
		/// Инициализирует Активную задачу с подзадачами.
		/// </summary>
		/// <param name="subToDos">Подзадачи</param>
		public ActiveToDoModel(IEnumerable<SubToDo> subToDos)
			: base(subToDos) { }
    }
}
