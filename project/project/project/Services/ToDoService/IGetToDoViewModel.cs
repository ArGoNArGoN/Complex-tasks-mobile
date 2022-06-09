using project.ViewModels;

using System;
using System.Collections.Generic;

namespace project.Services.ToDoService
{
    public interface IGetToDoViewModel
	{
		IEnumerable<BaseToDoViewModel> Get();
        BaseToDoViewModel Get(int identity);
    }
}
