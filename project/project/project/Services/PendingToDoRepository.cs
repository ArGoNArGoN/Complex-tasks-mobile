using project.Models;
using project.Services.Entitys;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services
{
    public class PendingToDoRepository
		: BaseToDoRepository
	{
		public IEnumerable<PendingToDoModel> Get()
        {
			var entitys = ToDoContext.Select().ToList();
			var subentitys = SubToDoContext.Select().ToList();

			List<PendingToDoModel> list = new List<PendingToDoModel>();

            foreach (var item in entitys.Where(x => x.Status == 0))
            {
				var model = new PendingToDoModel(subentitys.Where(x => x.ToDoIdentity == item.Identity).Select(x => x.Status == 0 ? new ActiveSubToDo(x.Identity) { Title = x.Title } : (SubToDoModel)new CompletedSubToDo(x.Identity) { Title = x.Title }))
				{
					Identity = item.Identity,

					Count = item.Count,
					Title = item.Title,
					Description = item.Description,
					EndDate = item.EndTime,
				};

				list.Add(model);
			}

			return list;
        }
	}
}
