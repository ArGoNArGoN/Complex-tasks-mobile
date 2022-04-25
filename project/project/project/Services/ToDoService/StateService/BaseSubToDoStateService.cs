using project.Models;
using project.Models.ToDo;
using project.Services.Entitys;

using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
    public abstract class BaseSubToDoStateService
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
				new SubModel(GetState())
				{
					Identity = x.Identity,
					ToDoIdentity = x.ToDoIdentity,

					Title = x.Title,
				}
			);
		}

		protected abstract IState<SubModel> GetState();
	}
}
