using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
	/// <summary>
	/// Отвечает за отображение Активных и Ожиающих задач
	/// </summary>
	public class ToDoItmesViewModel
		: BaseViewModel
	{
        private Boolean isRefreshing;

		/// <summary>
		/// VM активных задач.
		/// </summary>
		public ActiveToDoListViewModel ActiveToDoListViewModel { get; }
		/// <summary>
		/// VM ожидающих задач.
		/// </summary>
		public PendingToDoListViewModel PendingToDoListViewModel { get; }
		/// <summary>
		/// Инициализирует VM для работы с задачами
		/// </summary>
		public ToDoItmesViewModel()
		{
			ActiveToDoListViewModel = new ActiveToDoListViewModel();
			PendingToDoListViewModel = new PendingToDoListViewModel();
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

        public ICommand Refresh
		{
			get => new Command(() =>
			{
				ActiveToDoListViewModel.Refresh.Execute(this);
				PendingToDoListViewModel.Refresh.Execute(this);

				IsRefreshing = false;
			});
		}
	}
}
