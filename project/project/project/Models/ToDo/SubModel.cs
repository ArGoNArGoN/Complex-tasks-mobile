using project.Services.ToDoService.StateService.ModelService;
using System;

namespace project.Models.ToDo
{
	public class SubModel
		: BaseModel
	{
		private String title;
		private readonly ISaveSubToDoModel<SubModel> _services;
		public SubModel(IState<SubModel> state, ISaveSubToDoModel<SubModel> services)
		{
			State = state;
			_services = services;
		}

		public IState<SubModel> State { get; protected set; }

		public Int32 Identity { get; set; }
		public Int32 ToDoIdentity { get; set; }
		public String Title
		{
			get { return title; }
			set { title = value ?? ""; }
		}

		public void Commit()
		{
			State.Commit(this, (ob) => {
				this.State = ob;
				_services.Save(this);
			});
		}
		public void RollBack()
		{
			State.RollBack(this, (ob) => {
				this.State = ob;
				_services.Save(this);
			});
		}
	}
}