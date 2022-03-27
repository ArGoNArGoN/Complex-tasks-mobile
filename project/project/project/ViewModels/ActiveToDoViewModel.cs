using project.Models;
using System;
using System.Linq;

namespace project.ViewModels
{
    public class ActiveToDoViewModel
        : ToDoViewModel<ActiveToDoModel>
    {
        public ActiveToDoViewModel()
            : this (new ActiveToDoModel()) { }
        public ActiveToDoViewModel(ActiveToDoModel toDo)
            : base (toDo) { }

        public Boolean IsEmptySubToDos { get => this.ToDo.SubToDosIsEmpty; }

        public Int32 GetCountCompletedSubToDos { get => this.ToDo.SubToDos.OfType<CompletedSubToDo>().Count(); }
        public Int32 GetCountActiveSubToDos { get => this.ToDo.SubToDos.OfType<CompletedSubToDo>().Count(); }
        public Int32 GetAllCountSubToDos { get => this.ToDo.SubToDos.Count(); }
    }
}
