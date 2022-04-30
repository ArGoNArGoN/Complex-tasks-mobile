using project.Models.ToDo;

namespace project.ViewModels
{
    public abstract class BaseSubToDoViewModel
        : BaseViewModel
    {
        public BaseSubToDoViewModel(SubModel model)
            : base()
        {
            Model = model;
        }

        protected SubModel Model { get; }
    }
}
