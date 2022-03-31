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
    }
}