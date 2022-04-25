using project.Services.ToDoService.StateService.ModelService;
using System;

namespace project.Models.ToDo
{
	public class ToDoModel
		: BaseToDoModel
	{
		private readonly ISaveToDoModel<ToDoModel> saveService;

		public ToDoModel(IStateToDo state, ISaveToDoModel<ToDoModel> saveService)
			: base(state)
		{
			this.saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
		}

		public override String Commit()
			=> State.Commit(this, (state) => 
			{ 
				State = state;
				saveService.Save(this);
			});
		public override String RollBack()
			=> State.RollBack(this, (state) => 
			{
				State = state;
				saveService.Save(this);
			});
	}
}