using project.Models;
using project.Models.ToDo;
using project.Services.Entitys;
using project.Services.ToDoService.StateService.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project.Services.ToDoService.StateService
{
	public abstract class BaseToDoSubsStateService
		: ISaveToDoModel<ToDoSubsModel>
	{
		protected ICRUD<ToDoEntity> service { get; }
		
		protected BaseToDoSubsStateService(ICRUD<ToDoEntity> service)
		{
			this.service = service
				?? throw new ArgumentNullException(nameof(service));
		}

		protected virtual IEnumerable<ToDoSubsModel> CastEntityIntoModel(IEnumerable<ToDoEntity> entities)
		{
			if (entities is null)
				throw new ArgumentNullException(nameof(entities));

			if (entities.Count() == 0)
				return new List<ToDoSubsModel>();

			var service = SubToDoModelService.GetService();

			return entities.Where(x => x.TypeTask == "ToDoSubs")
				.Select(x => new ToDoSubsModel(GetState(), service.Get()
					.Where(y => y.ToDoIdentity == x.Identity))
				{
					Identity = x.Identity,
					Title = x.Title,
					Count = x.Count,
					Description = x.Description,
					EndDate = x.EndTime,
					Executor = x.Executor,
					Creator = x.Creator,
				}
			);
		}

		protected abstract IStateToDo GetState();

		public virtual void Save(ToDoSubsModel model)
		{
			var entity = service.Read(model.Identity) ?? new ToDoEntity();

			entity.Title = model.Title;
			entity.Count = model.Count;
			entity.Description = model.Description;
			entity.EndTime = model.EndDate;
			entity.Executor = model.Executor;
			entity.Creator = model.Creator;

			var collection = model.SubToDos;

			service.Update(entity);
		}
	}
}
