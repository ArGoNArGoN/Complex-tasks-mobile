using project.Models;
using project.Models.ToDo;
using project.Services;
using project.Services.Entitys;
using project.Services.ToDoService;
using project.Services.ToDoService.StateService;
using project.Services.ToDoService.StateService.ModelService;
using project.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace project
{
    public partial class App 
		: Application
	{
		public App()
		{
			this.InitializeComponent();

			this.RegisterDataStore();
			this.RegisterRoute();

			this.MainPage = new MainPage();
		}

		private const string DATABASE_NAME = "todos.db";
		public static readonly SQLiteConnection connection = new SQLiteConnection(Path.Combine(
							Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

        public ICRUD<ToDoEntity> GetToDoCrudService { get; private set; }
        public ICRUD<SubToDoEntity> GetSubToDoCrudService { get; private set; }

		private void RegisterRoute()
        {
			/// регистрация основных view
			Routing.RegisterRoute(nameof(Views.ListToDoView).ToLower(), typeof(Views.ListToDoView)); /// список задач
			Routing.RegisterRoute(nameof(Views.ListEventsView).ToLower(), typeof(Views.ListEventsView)); /// список событий

			/// регистрация дополнительных view
			Routing.RegisterRoute($"{nameof(Views.ListToDoView)}/{nameof(Views.ToDoView)}", typeof(Views.ToDoView)); /// список задач - задача
		}

		/// <summary>
		/// Регистрирует и настраивает все сервисы 
		/// </summary>
		private void RegisterDataStore()
		{
			/// !!!!! ПЕРЕД ТЕМ, КАК ИЗМЕНИТЬ !!!!!!
			/// ВАЖЕН ПОРЯДОК
			/// СМОТРИ ДОКИ В StarUML

			/// объявляем datastore
			GetToDoCrudService = new ToDoDataBaseContext(connection);
			GetSubToDoCrudService = new SubToDoDataBaseContext(connection);


			/// Рtгистрация сервисов для моделей.
			RegisterSubToDoModelService();
			RegisterToDoModelServices();
			RegisterToDoSubsModelServices();

			/// регистрация сервисов. 
			RegisterToDosViewModelService();
		}

        private void RegisterToDoSubsModelServices()
		{
			/// получаем объект CRUD сервиса
			ICRUD<ToDoEntity> crudService = GetToDoCrudService;

			/// создаем список сервисов с состояниями
			var collectionServices = new List<IStateService<ToDoSubsModel>>()
			{
				new PendingToDoSubsStateService(crudService),
				new ActiveToDoSubsStateService(crudService),
				new CompletedToDoSubsSateService(crudService),
			};

			/// инициализируем сервис ToDoSubs
			ToDoSubsModelService.InitializeService(collectionServices);
		}

        private void RegisterSubToDoModelService()
        {
			ICRUD<SubToDoEntity> crudService = GetSubToDoCrudService;

			var collectionServices = new List<IStateService<SubModel>>()
			{
				new PendingSubToDoStateService(crudService),
				new CompletedSubToDoStateService(crudService),
			};

			SubToDoModelService.InitializeService(collectionServices);
        }

        private void RegisterToDosViewModelService()
        {
			var collectionViewModel = new List<IGetToDoViewModel>()
			{
				new ToDoViewModelRepository(),
				new ToDoSubsViewModelRepository(), 
			};

			ToDosViewModelService.InitializeService(collectionViewModel);
		}

        /// <summary>
        /// Инициализирует сервис с состояниями для ToDo
        /// </summary>
        private void RegisterToDoModelServices()
        {
			/// получаем объект CRUD сервиса
			ICRUD<ToDoEntity> crudService = GetToDoCrudService;

			/// создаем список сервисов с состояниями
			var collectionServices = new List<IStateService<ToDoModel>>()
			{
				new PendingToDoStateService(crudService),
				new ActiveToDoStateService(crudService),
				new CompletedToDoSateService(crudService),
			};

			/// инициализируем сервис ToDo
			ToDoModelService.InitializeService(collectionServices);
        }

        protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
