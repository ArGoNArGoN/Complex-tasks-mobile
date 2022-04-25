using project.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoItems 
        : ContentView
    {
        public ToDoItems()
        {
            InitializeComponent();
        }
    }
}