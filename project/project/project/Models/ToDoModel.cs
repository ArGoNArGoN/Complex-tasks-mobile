using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Models
{
    public class ToDoModel
        : BaseToDoModel
    {
        protected String description = "";

        public ToDoModel() 
            : this(new List<SubToDo>()) { }
        public ToDoModel(IEnumerable<SubToDo> subToDos)
            : base()
        {
            SubToDos = subToDos ?? new List<SubToDo>();
        }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public String Description { get => this.description; set => description = value?.Trim() ?? ""; }
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