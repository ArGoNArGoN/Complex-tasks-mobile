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
    }
}
