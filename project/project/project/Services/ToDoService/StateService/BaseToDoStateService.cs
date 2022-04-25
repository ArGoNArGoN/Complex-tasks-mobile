using project.Models;
using project.Models.ToDo;
using project.Services.Entitys;
using project.Services.ToDoService.StateService.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService
{
	public abstract class BaseToDoStateService
		: ISaveToDoModel<ToDoModel>
	{
		protected ICRUD<ToDoEntity> service { get; }

		protected BaseToDoStateService(ICRUD<ToDoEntity> service)
		{
			this.service = service
				?? throw new ArgumentNullException(nameof(service));
		}
		protected virtual IEnumerable<ToDoModel> CastEntityIntoModel(IEnumerable<ToDoEntity> entities)
		{
			if (entities is null)
				throw new ArgumentNullException(nameof(entities));

			if (entities.Count() == 0)
				return new List<ToDoModel>();

			return entities.Where(x => x.TypeTask == "ToDo")
				.Select(x => new ToDoModel(GetState(), this)
                {
					Identity=x.Identity,
					Title=x.Title,
					Count=x.Count,
					Description=x.Description,
					EndDate=x.EndTime,
					Executor=x.Executor,
					Creator=x.Creator,
				}
			);
		}

		protected abstract IStateToDo GetState();

		public virtual void Save(ToDoModel model)
		{
			var entity = service.Read(model.Identity) ?? new ToDoEntity();

			entity.Title = model.Title;
			entity.Count = model.Count;
			entity.Description = model.Description;
			entity.EndTime = model.EndDate;
			entity.Executor = model.Executor;
			entity.Creator = model.Creator;
			entity.State = model.State.Value;

			service.Update(entity);
		}
	}
}