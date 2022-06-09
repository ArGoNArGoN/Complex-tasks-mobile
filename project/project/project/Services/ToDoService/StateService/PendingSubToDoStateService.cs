using project.Models;
using project.Models.ToDo;
using project.Models.ToDo.ToDoState;
using project.Services.Entitys;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public class PendingSubToDoStateService
        : BaseSubToDoStateService, IStateService<SubModel>
    {
        public PendingSubToDoStateService(ICRUD<SubToDoEntity> service) 
            : base(service) { }

        public IEnumerable<SubModel> Get()
        {
            var collection = service.Read();

            var activeToDos = collection.Where(x => x.Status == "PendingState");

            return this.CastEntityIntoModel(activeToDos);
        }

        public SubModel Get(int identity)
        {
            return null;
        }

        protected override IState<SubModel> GetState()
           => new PendingSubState();


    }
}
