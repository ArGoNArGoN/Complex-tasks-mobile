using System;
using System.Threading.Tasks;

namespace project.Services.ServiceDialog
{
    public interface IServiceDialog
    {
        Task ShowAsync(String message);
        Task ShowDialogAsync(string title, string message, string cancel);
        Task<String> ShowDialogAsync(String title, String description, String leftAction, String rightAction);
        Task ShowDialogAsync(String title, String description, String nameLeftAction, String nameRightAction, Action leftAction, Action rightAction);
    }
}
