using project.Models;
using project.Services.Entitys;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services
{
    public class ActiveToDoRepository
		: BaseToDoRepository, IRepository<ActiveToDoModel, Int32>
	{
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActiveToDoModel> Get()
        {
			var entitys = ToDoContext.Select().ToList();
			var subentitys = SubToDoContext.Select().ToList();

			List<ActiveToDoModel> list = new List<ActiveToDoModel>();

            foreach (var item in entitys.Where(x => x.Status == 1))
            {
				var model = new ActiveToDoModel(subentitys.Where(x => x.ToDoIdentity == item.Identity).Select(x => x.Status == 0 ? new ActiveSubToDo(x.Identity) { Title = x.Title } : (SubToDoModel)new CompletedSubToDo(x.Identity) { Title = x.Title }))
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

        public ActiveToDoModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(ActiveToDoModel item)
        {
            throw new NotImplementedException();
        }
    }
}
