using project.Models.ToDo.ToDoState;
using project.Services;

using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace project.ViewModels
{
    public class CompletedToDoCollectionViewModel
		: BaseCollectionToDoViewModels
	{
		private ToDosViewModelService _service = ToDosViewModelService.GetService();

        public CompletedToDoCollectionViewModel()
        {
        }

        public override string TitleCollection => "Завершенные задачи";

		public async override void InitializeCollectionViewModel()
		{
			IsRefresh = true;

			try
			{
				var collection = await Task.Run(() => _service.Get()
					.Where(x => x.GetState is BaseCompletedToDoState));

				this.CollectionViewModels.Clear();

				foreach (var item in collection)
				{
					this.CollectionViewModels.Add(item);
				}
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", ex.Message);
				throw;
			}
		}

		public async override void OnRefrash()
		{
			IsRefresh = true;

			try
			{
				var collection = await Task.Run(() => _service.Get()
					.Where(x => x.GetState is BaseCompletedToDoState));

				this.CollectionViewModels.Clear();

                foreach (var item in collection)
                {
					this.CollectionViewModels.Add(item);
                }
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", ex.Message);
				throw;
			}
		}
	}
}
