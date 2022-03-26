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
		: BaseToDoModel
	{
		/// <summary>
		/// Список подзадач. 
		/// </summary>
		public IEnumerable<SubToDo> SubToDos { get; }

		/// <summary>
		/// Инициализирует Активную задачу.
		/// </summary>
		public ActiveToDoModel()
			: this(new List<SubToDo>()) { }
		/// <summary>
		/// Инициализирует Активную задачу с подзадачами.
		/// </summary>
		/// <param name="subToDos">Подзадачи</param>
		public ActiveToDoModel(IEnumerable<SubToDo> subToDos)
			: base()
		{
			SubToDos = subToDos ?? new List<SubToDo>();
		}

		/// <summary>
		/// Проверяет, существуют ли подзадачи
		/// </summary>
		public Boolean SubToDosIsEmpty => SubToDos.Count() == 0;
	}
}
