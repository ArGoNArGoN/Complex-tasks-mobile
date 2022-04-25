using project.Models.ToDo;
using project.ViewModels;
using System.Collections.Generic;

namespace project.Services.ToDoService
{
    public interface IGetToDoViewModel
	{
		IEnumerable<BaseToDoViewModel> Get();
	}
}
