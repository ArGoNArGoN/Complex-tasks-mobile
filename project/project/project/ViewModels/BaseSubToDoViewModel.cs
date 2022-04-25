using project.Models.ToDo;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.ViewModels
{
    public class BaseSubToDoViewModel
        : BaseViewModel
    {
        public BaseSubToDoViewModel(SubModel model)
            : base()
        {
            Model = model;
        }

        public SubModel Model { get; }
    }
}
