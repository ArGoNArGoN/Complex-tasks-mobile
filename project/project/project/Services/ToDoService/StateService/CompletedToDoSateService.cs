using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public class CompletedToDoSateService
        : BaseToDoStateService, IStateService<ToDoModel>
    {
        public CompletedToDoSateService(ICRUD<ToDoEntity> service)
            : base(service) { }

        public IEnumerable<ToDoModel> Get()
        {
            var collection = service.Read();

            var activeToDos = collection.Where(x => x.State == "Завершенная");

            return this.CastEntityIntoModel(activeToDos);
        }

        public ToDoModel Get(int identity)
        {
            var model = service.Read(identity);
            if (model.State == "Завершенная" && model.TypeTask == "ToDo")
            {
                return this.CastEntityIntoModel(model);
            }
            return null;
        }

        protected override IStateToDo GetState()
            => new CompletedToDoState();
    }
}
