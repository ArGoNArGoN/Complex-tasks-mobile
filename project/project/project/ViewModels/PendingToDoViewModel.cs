using project.Models;
using project.Services;
using System;
using System.Linq;

namespace project.ViewModels
{
	public class PendingToDoViewModel
		: ToDoViewModel<PendingToDoModel>
    {
        public PendingToDoViewModel()
            : this(new PendingToDoModel()) { }
        public PendingToDoViewModel(PendingToDoModel toDo)
            : base(toDo) { }

        public Boolean IsEmptySubToDos { get => this.ToDo.SubToDosIsEmpty; }

        public Int32 GetCountCompletedSubToDos { get => this.ToDo.SubToDos.OfType<CompletedSubToDo>().Count(); }
        public Int32 GetCountActiveSubToDos { get => this.ToDo.SubToDos.OfType<CompletedSubToDo>().Count(); }
        public Int32 GetAllCountSubToDos { get => this.ToDo.SubToDos.Count(); }
    }
}