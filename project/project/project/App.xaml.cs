using project.Models;
using project.Models.ToDo;
using project.Services;
using project.Services.Entitys;
using project.Services.Entitys.APIService;
using project.Services.Entitys.DBService;
using project.Services.Entitys.ScopeService;
using project.Services.ServiceDialog;
using project.Services.ToDoService;
using project.Services.ToDoService.StateService;
using project.Services.ToDoService.StateService.ModelService;
using project.Services.UserService;
using project.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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

			this.MainPage = new NavigationPage(new AuthorizationView());
		}

		private const string DATABASE_NAME = "todos.db";
		public static readonly SQLiteConnection connection = new SQLiteConnection(Path.Combine(
							Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
		
		public ICRUD<ToDoEntity> GetToDoCrudService { get; private set; }
		public ICRUD<SubToDoEntity> GetSubToDoCrudService { get; private set; }
		public ICRUD<UserEntity> UserDBCrudService { get; private set; }

		private void RegisterRoute()
		{
			/// регистрация основных view
			Routing.RegisterRoute(nameof(Views.ListToDoView).ToLower(), typeof(Views.ListToDoView)); /// список задач
			Routing.RegisterRoute(nameof(Views.CollectionCompletedToDoView).ToLower(), typeof(Views.CollectionCompletedToDoView)); /// список событий

			/// регистрация дополнительных view
			Routing.RegisterRoute($"{nameof(Views.ToDoView)}", typeof(Views.ToDoView)); /// список задач - задача
		}

		/// <summary>
		/// Регистрирует и настраивает все сервисы 
		/// </summary>
		private void RegisterDataStore()
		{
			/// !!!!! ПЕРЕД ТЕМ, КАК ИЗМЕНИТЬ !!!!!!
			/// ВАЖЕН ПОРЯДОК
			/// СМОТРИ ДОКИ

			/// объявляем datastore
			/// Заменить на прослойку
			GetToDoCrudService = new ToDoScopeService(new ToDoDataBaseContext(connection), new ToDoEntityAPIContext(), new UserChangesDataBaseContext(connection));
			GetSubToDoCrudService = new SubToDoDataBaseContext(connection);

			/// регистрация сервиса для получения пользователя
			UserDBCrudService = new UserDataBaseContext(connection);
			DependencyService.RegisterSingleton(UserDBCrudService);
			DependencyService.RegisterSingleton(new ServiceDialogCurrentIntent());
			DependencyService.RegisterSingleton<IAuthorizationService>(new UserModelRepository(UserDBCrudService));

			/// Рtгистрация сервисов для моделей.
			RegisterToDoModelServices();
			RegisterSubToDoModelService();
			RegisterToDoSubsModelServices();

			/// регистрация сервисов. 
			RegisterToDosViewModelService();
		}

		private void RegisterToDoSubsModelServices()
		{
			/// Тут багулина, я не знаю, как ее фиксить иначе
			/// Почему-то сервис может быть уже инициализирован
			/// а вот почему, мы не знаем, спросить Нижегородову
			/// Завести баг, если еще можно успеть
			if (ToDoSubsModelService.IsInit)
				return;

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
			/// Тут багулина, я не знаю, как ее фиксить иначе
			/// Почему-то сервис может быть уже инициализирован
			/// а вот почему, мы не знаем, спросить Нижегородову
			/// Завести баг, если еще можно успеть
			if (SubToDoModelService.IsInit)
				return;

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
			/// Тут багулина, я не знаю, как ее фиксить иначе
			/// Почему-то сервис может быть уже инициализирован
			/// а вот почему, мы не знаем, спросить Нижегородову
			/// Завести баг, если еще можно успеть
			if (ToDosViewModelService.IsInit)
				return;

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
			/// Тут багулина, я не знаю, как ее фиксить иначе
			/// Почему-то сервис может быть уже инициализирован
			/// а вот почему, мы не знаем, спросить Нижегородову
			/// Завести баг, если еще можно успеть
			if (ToDoModelService.IsInit)
				return;

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
