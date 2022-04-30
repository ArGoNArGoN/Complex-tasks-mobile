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
			IsRefresh = true;

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
				IsRefresh = false;
			}
		}

		public async override void OnRefrash()
		{
			/// TODO: Проверить на дубликацю события
			IsRefresh = true; /// почему здесь true? При установке дублируется событие

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
				IsRefresh = false;
			}
		}
	}
}
