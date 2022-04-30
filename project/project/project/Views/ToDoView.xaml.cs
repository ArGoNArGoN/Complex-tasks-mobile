using project.ViewModels;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToDoView 
		: ContentPage
	{
		ToDoViewViewModel _VM;
		public ToDoView()
		{
			InitializeComponent();
			InintBinding();
		}
		
		private void InintBinding()
		{
			BindingContext = _VM = new ToDoViewViewModel();
		}

		protected override bool OnBackButtonPressed()
		{
			_VM?.BackCommand.Execute(new Object()); /// посылаем что-то, но не null
			return base.OnBackButtonPressed();
		}
	}
}