using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
	/// <summary>
	/// Отвечает за отображение Активных и Ожиающих задач
	/// </summary>
	[QueryProperty(nameof(ParameterIsRefrash), nameof(ParameterIsRefrash))]
	public class CollectionStateViewModel
		: BaseViewModel
	{
        private Boolean isRefreshing;

		/// <summary>
		/// VM активных задач.
		/// </summary>
		public ActiveToDoCollectionViewModel ActiveToDoListViewModel { get; }
		/// <summary>
		/// VM ожидающих задач.
		/// </summary>
		public PendingToDoCollectionViewModel PendingToDoListViewModel { get; }

		/// <summary>
		/// Инициализирует VM для работы с задачами
		/// </summary>
		public CollectionStateViewModel()
		{
			ActiveToDoListViewModel = new ActiveToDoCollectionViewModel();
			PendingToDoListViewModel = new PendingToDoCollectionViewModel();
		}

        public override String ParameterIsRefrash 
		{
			get => base.ParameterIsRefrash;
			set
			{
				base.ParameterIsRefrash = value;
				if (Boolean.TryParse(value, out var result)) IsRefreshing = result;
			}
		}

        public Boolean IsRefreshing
		{
            get { return isRefreshing; }
            set 
			{
				isRefreshing = value; 
				OnPropertyChanged(nameof(IsRefreshing));
			}
        }

		public ICommand RefreshButtonCommand 
		{ 
			get => new Command(() => IsRefreshing = true);
		}
		public ICommand RefreshCommand => new Command(() =>
		{
			IsRefreshing = true;

			ActiveToDoListViewModel.RefrashCommand.Execute(this);
			PendingToDoListViewModel.RefrashCommand.Execute(this);

			IsRefreshing = false;
		});
    }
}
