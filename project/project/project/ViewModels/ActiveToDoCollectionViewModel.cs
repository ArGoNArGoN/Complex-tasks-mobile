using project.Models.ToDo.ToDoState;
using project.Services;

using System.Linq;
using System.Threading.Tasks;

namespace project.ViewModels
{
	/// <summary>
	/// Отображение активных задач
	/// </summary>
	public class ActiveToDoCollectionViewModel
		: BaseCollectionToDoViewModels
	{
		private ToDosViewModelService _service = ToDosViewModelService.GetService();

		public ActiveToDoCollectionViewModel() { }

		public override string TitleCollection => "Активные задачи";

		public async override void InitializeCollectionViewModel()
		{
			IsRefrash = true;

			try
			{
				var collection = await Task.Run(() => _service.Get()
					.Where(x => x.GetState is BaseActiveToDoState));
				
				this.CollectionViewModels.Clear();
				
				foreach (var item in collection)
				{
					CollectionViewModels.Add(item);
				}
			}
			finally
			{
				IsRefrash = false;
			}
		}

		public async override void OnRefrash()
		{
			IsRefrash = true;

			try
			{
				var collection = await Task.Run(() => _service.Get()
					 .Where(x => x.GetState is BaseActiveToDoState));

				this.CollectionViewModels.Clear();
				
				foreach (var item in collection)
				{
					CollectionViewModels.Add(item);
				}
			}
			finally
			{
				IsRefrash = false;
			}
		}
	}
}
