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
    public partial class ToDo : ContentView
    {
        public ToDo()
        {
            InitializeComponent();
        }

        /// @bug SizeChanged эта штука фиксит баг c прорисовкой элементов
        private async void SizeChanged(object sender, System.EventArgs e)
        {
            await Task.Delay(100);

            InvalidateMeasure();
            ForceLayout();
        }
    }
}