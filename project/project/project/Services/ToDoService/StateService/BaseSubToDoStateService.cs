using project.Models;
using project.Models.ToDo;
using project.Services.Entitys;
using project.Services.ToDoService.StateService.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public abstract class BaseSubToDoStateService
		: ISaveSubToDoModel<SubModel>
	{
		protected ICRUD<SubToDoEntity> service { get; }

		protected BaseSubToDoStateService(ICRUD<SubToDoEntity> service)
		{
			this.service = service
				?? throw new ArgumentNullException(nameof(service));
		}

		protected virtual IEnumerable<SubModel> CastEntityIntoModel(IEnumerable<SubToDoEntity> entities)
		{
			if (entities is null)
				throw new ArgumentNullException(nameof(entities));

			if (entities.Count() == 0)
				return new List<SubModel>();

			return entities.Select(x =>
				new SubModel(GetState(), this)
				{
					Identity = x.Identity,
					ToDoIdentity = x.ToDoIdentity,

					Title = x.Title,
				}
			);
		}

		protected abstract IState<SubModel> GetState();

        public void Save(SubModel model)
		{
			var entity = service.Read(model.Identity) ?? new SubToDoEntity();

			entity.Title = model.Title;
			entity.Status = model.State.Value;

			service.Update(entity);
		}
    }
}
