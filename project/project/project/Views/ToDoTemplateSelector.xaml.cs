using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoTemplateSelector : ContentView
    {
        public ToDoTemplateSelector()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Log.Warning("ERROR", ex.ToString());
            }
        }
    }
}