using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
	public sealed class ActiveToDoStateService
		: BaseToDoStateService, IStateService<ToDoModel>
	{
		public ActiveToDoStateService(ICRUD<ToDoEntity> service)
			: base(service) { }

		protected override IStateToDo GetState()
			=> new ActiveToDoState();

		public IEnumerable<ToDoModel> Get()
		{
			var collection = service.Read();

			var activeToDos = collection.Where(x => x.State == "Активная");

			return this.CastEntityIntoModel(activeToDos);
		}

        public ToDoModel Get(int identity)
		{
			var model = service.Read(identity);
			if (model.State == "Активная" && model.TypeTask == "ToDo")
            {
				return this.CastEntityIntoModel(model);
            }
			return null;
		}
    }
}
