using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public sealed class PendingToDoStateService
		: BaseToDoStateService, IStateService<ToDoModel>
	{
		public PendingToDoStateService(ICRUD<ToDoEntity> service)
			: base(service) { }

		protected override IStateToDo GetState()
			=> new PendingToDoState();

		public IEnumerable<ToDoModel> Get()
		{
			var collection = service.Read();

			var activeToDos = collection.Where(x => x.State == "Ожидающая");

			return this.CastEntityIntoModel(activeToDos);
		}
	}
}
