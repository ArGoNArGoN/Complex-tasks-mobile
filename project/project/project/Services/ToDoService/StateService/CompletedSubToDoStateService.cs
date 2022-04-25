using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public class CompletedSubToDoStateService
		: BaseSubToDoStateService, IStateService<SubModel>
    {
        public CompletedSubToDoStateService(ICRUD<SubToDoEntity> service)
            : base(service) { }

        public IEnumerable<SubModel> Get()
        {
            var collection = service.Read();

            var activeToDos = collection.Where(x => x.Status == "CompletedState");

            return this.CastEntityIntoModel(activeToDos);
        }

        protected override IState<SubModel> GetState()
           => new CompletedSubState();
    }
}
