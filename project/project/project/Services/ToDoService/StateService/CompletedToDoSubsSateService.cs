using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public class CompletedToDoSubsSateService
        : BaseToDoSubsStateService, IStateService<ToDoSubsModel>
    {
        public CompletedToDoSubsSateService(ICRUD<ToDoEntity> service)
            : base(service) { }

        public IEnumerable<ToDoSubsModel> Get()
        {
            var collection = service.Read();

            var activeToDos = collection.Where(x => x.State == "Завершенная");

            return this.CastEntityIntoModel(activeToDos);
        }

        public ToDoSubsModel Get(int identity)
        {
            return null;
        }

        protected override IStateToDo GetState()
            => new CompletedToDoSubsState();
    }
}
