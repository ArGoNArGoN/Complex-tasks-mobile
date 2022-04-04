using project.Services;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace project
{
    public partial class App : Application
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

		private void RegisterRoute()
        {
			/// регистрация основных view
			Routing.RegisterRoute(nameof(Views.ListToDoView).ToLower(), typeof(Views.ListToDoView)); /// список задач
			Routing.RegisterRoute(nameof(Views.ListEventsView).ToLower(), typeof(Views.ListEventsView)); /// список событий

			/// регистрация дополнительных view
			Routing.RegisterRoute($"{nameof(Views.ListToDoView).ToLower()}/{nameof(Views.ToDoItemView)}", typeof(Views.ListToDoView)); /// список задач - задача
		}

		private void RegisterDataStore()
		{
			DependencyService.RegisterSingleton<ActiveToDoRepository>(new ActiveToDoRepository());
			DependencyService.RegisterSingleton<PendingToDoRepository>(new PendingToDoRepository());
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
