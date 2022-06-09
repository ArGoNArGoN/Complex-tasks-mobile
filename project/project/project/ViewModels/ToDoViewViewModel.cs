using project.Services;
using project.Services.ToDoService;

using System;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Forms.Internals;
using System.Threading.Tasks;

namespace project.ViewModels
{
	[QueryProperty(nameof(Identity), nameof(Identity))]
	public sealed class ToDoViewViewModel
		: BaseViewModel
	{
		#region Сервисы и необходимые данные
		private Int32 identity;
		private Boolean isRefresh;
		private IGetToDoViewModel _serviceToDo = ToDosViewModelService.GetService();
		#endregion

		#region VM по ToDo
		private BaseToDoViewModel toDoViewModel;
		private CollectionCommetsViewModel colectionCommetsViewModel;
		private CollectionEventsViewModel colectionEventsViewModel;

        public BaseToDoViewModel ToDoViewModel { get => toDoViewModel; private set { toDoViewModel = value; OnPropertyChanged(nameof(ToDoViewModel)); } }
		public CollectionCommetsViewModel ColectionCommetsViewModel { get => colectionCommetsViewModel; private set { colectionCommetsViewModel = value; OnPropertyChanged(nameof(ColectionCommetsViewModel)); } }
		public CollectionEventsViewModel ColectionEventsViewModel { get => colectionEventsViewModel; private set { colectionEventsViewModel = value; OnPropertyChanged(nameof(ColectionEventsViewModel)); } }
		#endregion

		public ToDoViewViewModel() { }

		public String Identity { get => identity.ToString(); set => OnSetToDoModel(value); }

		// private Boolean slipRefrash { get; set; }

		public Boolean IsRefresh
		{
			get => isRefresh;
			set 
			{ 
				if (isRefresh != value)
                {
					isRefresh = value;
					OnPropertyChanged(nameof(IsRefresh));
                }
			}
		}

		public ICommand RefrashCommand { get; private set; }
		public ICommand OnRefrashCommand { get => new Command(() => IsRefresh = true); }
		
		public ICommand BackCommand => new Command(async () => await Shell.Current.GoToAsync("..?ParameterIsRefresh=true"));

		private async void OnSetToDoModel(String identiy)
		{
			Int32.TryParse(identiy, out identity);

			if (!(identity > 0))
            {
				Log.Warning("ERROR", "identity < 1, ToDoViewViewModel");
				await Shell.Current.GoToAsync("..");
				return;
            }

			TitlePage = identity.ToString();

			try
			{
				InitToDoViewModel();
				InitColectionCommetsViewModel();
				InitColectionEventsViewModel();
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", "Ошибка при попытке инициализировать VM для ToDoView: " + ex.ToString());
				throw;
			}

			InitCommand();
		}

		private void Refrash()
		{
			try
			{
				InitToDoViewModel();
				InitColectionCommetsViewModel();
				InitColectionEventsViewModel();
			}
			catch (Exception ex)
			{
				Log.Warning("ERROR", "Ошибка при обновлении VM для ToDoView: " + ex.ToString());
				throw;
			}
			finally
			{
				IsRefresh = false;
			}
		}
		
		private void InitCommand()
		{
			RefrashCommand = new Command(Refrash);
			OnPropertyChanged(nameof(RefrashCommand));
		}

		private void InitColectionEventsViewModel()
		{
		}
		private void InitColectionCommetsViewModel()
		{
		}
		private async void InitToDoViewModel()
		{
			try
			{
				ToDoViewModel = await Task.Run(() => _serviceToDo.Get(identity)
					?? throw new ArgumentException($"ToDoVM не найден: identity = {identity}", nameof(identity)));
			}
			catch (ArgumentException ex)
			{
				Log.Warning("ERROR", ex.ToString());
			}

			ToDoViewModel.Refrash += Refrash;
		}
	}
}
