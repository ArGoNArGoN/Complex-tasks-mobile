using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Models
{
    public class ToDoModel
        : BaseToDoModel
    {
        public ToDoModel() 
            : this(new List<SubToDo>()) { }
        public ToDoModel(IEnumerable<SubToDo> subToDos)
            : base()
        {
            SubToDos = subToDos ?? new List<SubToDo>();
        }

        /// <summary>
        /// Список подзадач. 
        /// </summary>
        public IEnumerable<SubToDo> SubToDos { get; }

        /// <summary>
        /// Проверяет, существуют ли подзадачи
        /// </summary>
        public Boolean SubToDosIsEmpty => SubToDos.Count() == 0;
    }
}