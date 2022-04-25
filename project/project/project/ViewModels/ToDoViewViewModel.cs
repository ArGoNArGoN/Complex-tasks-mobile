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
		private Boolean isRefrash;
		private IGetToDoViewModel _serviceToDo = ToDosViewModelService.GetService();
		#endregion

		#region VM по ToDo
		private BaseToDoViewModel toDoViewModel;
		private ColectionCommetsViewModel colectionCommetsViewModel;
		private ColectionEventsViewModel colectionEventsViewModel;

        public BaseToDoViewModel ToDoViewModel { get => toDoViewModel; private set { toDoViewModel = value; OnPropertyChanged(nameof(ToDoViewModel)); } }
		public ColectionCommetsViewModel ColectionCommetsViewModel { get => colectionCommetsViewModel; private set { colectionCommetsViewModel = value; OnPropertyChanged(nameof(ColectionCommetsViewModel)); } }
		public ColectionEventsViewModel ColectionEventsViewModel { get => colectionEventsViewModel; private set { colectionEventsViewModel = value; OnPropertyChanged(nameof(ColectionEventsViewModel)); } }
		#endregion

		public ToDoViewViewModel() { }

		public String Identity { get => identity.ToString(); set => OnSetToDoModel(value); }

		// private Boolean slipRefrash { get; set; }

		public Boolean IsRefrash
		{
			get => isRefrash;
			set 
			{ 
				if (isRefrash != value)
                {
					isRefrash = value;
					OnPropertyChanged(nameof(IsRefrash));
                }
			}
		}

		public ICommand RefrashCommand { get; private set; }
		public ICommand OnRefrashCommand { get => new Command(() => IsRefrash = true); }
		
		public ICommand BackCommand => new Command(async () => await Shell.Current.GoToAsync("..?ParameterIsRefrash=true"));

		private void OnSetToDoModel(String identiy)
		{
			Int32.TryParse(identiy, out identity);

			if (!(identity > 0))
				throw new ArgumentException("identity < 1", nameof(identity));

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
				IsRefrash = false;
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
				ToDoViewModel = _serviceToDo.Get()
					.FirstOrDefault(x => x.Identity == identity)
					?? throw new ArgumentException($"ToDoVM не найден: identity = {identity}", nameof(identity));
			}
			catch (ArgumentException ex)
			{
				Log.Warning("ERROR", $"ToDoVM не найден: identity = {identity}", ex.ToString());
				Log.Warning("ERROR", $"Повтор попытки...");

				try
				{
					ToDoViewModel = await Task.Run(() => _serviceToDo.Get()
						.FirstOrDefault(x => x.Identity == identity)
							?? throw new ArgumentException($"ToDoVM не найден: identity = {identity}", nameof(identity)));

					Log.Warning("INFO", "Успешно");
				}
				catch (ArgumentException ex2)
				{
					Log.Warning("ERROR", ex2.ToString());
					throw;
				}
			}

			ToDoViewModel.Refrash += Refrash;
		}
	}
}
