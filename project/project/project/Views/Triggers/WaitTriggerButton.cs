using System.Threading.Tasks;
using Xamarin.Forms;

namespace project.Views.Triggers
{
    public class WaitTriggerButton
        : TriggerAction<Button>
    {
        public WaitTriggerButton()
        {
        }

        protected override async void Invoke(Button sender)
        {
            sender.IsEnabled = false;
            await Task.Delay(1 * 1000);
            sender.IsEnabled = true;
        }
    }
}
