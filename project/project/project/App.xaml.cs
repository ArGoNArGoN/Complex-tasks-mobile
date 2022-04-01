using project.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
			DependencyService.Register<ToDoDataStore>();
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
