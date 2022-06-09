using project.Models;
using project.Models.ToDo;
using project.Services.Entitys;
using project.Services.ToDoService.StateService.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
					Source=x.Source,
					SourceCreator=x.SourceCreator,
					Title =x.Title,
					Count=x.Count,
					Description=x.Description,
					EndDate=x.EndDate,
					Executor=x.Executor,
					Creator=x.Creator,
				}
			);
		}
		protected virtual ToDoModel CastEntityIntoModel(ToDoEntity entitiy)
		{
			if (entitiy is null)
				throw new ArgumentNullException(nameof(entitiy));

			return new ToDoModel(GetState(), this)
			{
				Identity = entitiy.Identity,
				Source = entitiy.Source,
				SourceCreator = entitiy.SourceCreator,
				Title = entitiy.Title,
				Count = entitiy.Count,
				Description = entitiy.Description,
				EndDate = entitiy.EndDate,
				Executor = entitiy.Executor,
				Creator = entitiy.Creator,
			};
		}
		protected abstract IStateToDo GetState();

		public virtual async void Save(ToDoModel model)
		{
			var entity = await Task.Run(() => service.Read(model.Identity) ?? new ToDoEntity());

			entity.Title = model.Title;
			entity.Count = model.Count;
			entity.Description = model.Description;
			entity.EndDate = model.EndDate;
			entity.Executor = model.Executor;
			entity.Creator = model.Creator;
			entity.State = model.State.Value;

			service.Update(entity);
		}
	}
}