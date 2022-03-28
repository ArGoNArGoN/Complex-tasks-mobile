using project.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoItem : ContentView
    {
        public ToDoItem()
        {
            InitializeComponent();
        }
    }
}