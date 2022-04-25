using project.Services.ToDoService.StateService.ModelService;
using project.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService
{
    /// <summary>
    /// Сервис генерации ToDoViewModel.
    /// Должен генерировать ToDoViewModel для ToDoModel.
    /// </summary>
    public class ToDoViewModelRepository
		: IGetToDoViewModel
	{
		private ToDoModelService service;
		
		public ToDoViewModelRepository()
		{
			service = ToDoModelService.GetService();
		}

		public IEnumerable<BaseToDoViewModel> Get()
			=> service.Get()
			.Select(x => new ToDoViewModel(x));
    }
}
