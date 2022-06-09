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

			var activeToDos = collection.Where(x => x.State == "Ожидающая").ToList();
			var ds = activeToDos.Count();

			return this.CastEntityIntoModel(activeToDos);
		}
		public ToDoModel Get(int identity)
		{
			var model = service.Read(identity);
			if (model.State == "Ожидающая" && model.TypeTask == "ToDo")
			{
				return this.CastEntityIntoModel(model);
			}
			return null;
		}
	}
}
