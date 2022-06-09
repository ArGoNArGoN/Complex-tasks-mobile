using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public class ActiveToDoSubsStateService
        : BaseToDoSubsStateService, IStateService<ToDoSubsModel>
    {
        public ActiveToDoSubsStateService(ICRUD<ToDoEntity> service)
            : base(service) { }

        public IEnumerable<ToDoSubsModel> Get()
        {
            var collection = service.Read();

            var activeToDos = collection.Where(x => x.State == "Активная");

            return this.CastEntityIntoModel(activeToDos);
        }

        public ToDoSubsModel Get(int identity)
        {
            return null;
        }

        protected override IStateToDo GetState()
            => new ActiveToDoSubsState();
    }
}
