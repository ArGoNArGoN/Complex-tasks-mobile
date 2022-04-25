using project.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToDoView 
		: ContentPage
	{
		public ToDoView()
		{
			InitializeComponent();
			InintBinding();
		}

		private void InintBinding()
		{
			BindingContext = new ToDoViewViewModel();
		}
	}
}