using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace project.Services.ServiceDialog
{
    public class ServiceDialogCurrentIntent
        : IServiceDialog
    {
        public async Task ShowAsync(string message) 
            => await Application.Current.MainPage.DisplayAlert("Сообщение", message, "Ok");

        public async Task ShowDialogAsync(string title, string message, string cancel = "Ok") 
            => await Application.Current.MainPage.DisplayAlert(title, message, cancel);

        public async Task<string> ShowDialogAsync(string title, string message, string leftAction, string rightAction)
            => await Application.Current.MainPage.DisplayPromptAsync(title, message, leftAction, rightAction);

        public async Task ShowDialogAsync(string title, string message, string nameLeftAction, string nameRightAction, Action leftAction, Action rightAction)
        {
            var result = await ShowDialogAsync(title, message, nameLeftAction, nameRightAction);

            if (result == nameLeftAction)
                leftAction?.Invoke();

            else
                rightAction?.Invoke();
        }
    }
}
