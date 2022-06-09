using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoSubs : ContentView
    {
        public ToDoSubs()
        {
            InitializeComponent();
        }
        
        /// @bug SizeChanged эта штука фиксит баг c прорисовкой элементов
        private new async void SizeChanged(object sender, System.EventArgs e)
        {
            await Task.Delay(100);

            InvalidateMeasure();
            ForceLayout();
        }
    }
}