using project.Models.ToDo.ToDoState;
using project.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace project.ViewModels
{
    public class PendingToDoCollectionViewModel
        : BaseCollectionToDoViewModels
	{
		private ToDosViewModelService _service = ToDosViewModelService.GetService();

		public PendingToDoCollectionViewModel() : base() { }

		public override string TitleCollection => "Ожидающие задачи";

		public async override void InitializeCollectionViewModel()
		{
			IsRefrash = true;

			try
			{
				var collection = await Task.Run(() => _service.Get()
					.Where(x => x.GetState is BasePendingToDoState));

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
					.Where(x => x.GetState is BasePendingToDoState));

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
