using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
	/// <summary>
	/// Отвечает за отображение Активных и Ожиающих задач
	/// </summary>
	[QueryProperty(nameof(ParameterIsRefresh), nameof(ParameterIsRefresh))]
	public class CollectionStateViewModel
		: BaseViewModel
	{
        private Boolean isRefreshing;
        private String parameterIsRefresh;
        private Boolean isBusy;

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
		public virtual String ParameterIsRefresh 
		{
			get => parameterIsRefresh;
			set
			{
				parameterIsRefresh = value;
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

		public ICommand RefreshButtonCommand => new Command(() => IsRefreshing = true);
		public ICommand RefreshCommand => new Command(() =>
		{
			IsRefreshing = true;

			ActiveToDoListViewModel.RefreshCommand.Execute(this);
			PendingToDoListViewModel.RefreshCommand.Execute(this);

			IsRefreshing = false;
		});

		public async void OnOpenToDo(BaseToDoViewModel viewModel)
        {
			if (!isBusy)
			{
				isBusy = true;
				try
				{
					await Shell.Current.GoToAsync($"{nameof(Views.ToDoView)}?Identity={viewModel.Identity}", true);
				}
				finally
				{
					isBusy = false;
				}
			}
		}

		public virtual ICommand OnTapped => new Command<BaseToDoViewModel>(OnOpenToDo);
	}
}
