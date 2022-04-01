using project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoItems : ContentView
    {
        public ToDoItems()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var view = sender as ContentView;

            if (!(view?.BindingContext is BaseViewModel))
                return;

            await Navigation.PushAsync(new ToDoItemView() { BindingContext = view.BindingContext });
        }
    }
}