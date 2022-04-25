using project.Models.ToDo;
using project.Services.ToDoService.StateService.ModelService;

namespace project.ViewModels
{
	public class ToDoViewModel
		: BaseToDoViewModel
	{
		public ToDoViewModel(ToDoModel model)
			: base(model)
		{
			_model = model;
		}

		private ToDoModel _model;

		protected override void OnCommit()
		{
			StateMessage = model.Commit();
		}
		protected override void OnRolback()
		{
			StateMessage = model.RollBack();
		}
	}
}
