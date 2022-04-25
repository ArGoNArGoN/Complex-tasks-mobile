using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.Views.Triggers
{
    public class AlertTriggerContentView
        : TriggerAction<ContentView>
    {
        protected override async void Invoke(ContentView sender)
        {
            await Shell.Current.DisplayPromptAsync("Уведомление!", "");
        }
    }
}
