using project.ViewModels;
using project.Services.ToDoService.StateService.ModelService;

using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService
{
    /// <summary>
    /// Гененрирует VM для ToDoSubs.
    /// </summary>
    public class ToDoSubsViewModelRepository
		: IGetToDoViewModel
	{
		private ToDoSubsModelService service;
		public ToDoSubsViewModelRepository()
		{
			service = ToDoSubsModelService.GetService();
		}

		public IEnumerable<BaseToDoViewModel> Get()
			=> service.Get()
			.Select(x => new ToDoSubsViewModel(x));
	}
}
