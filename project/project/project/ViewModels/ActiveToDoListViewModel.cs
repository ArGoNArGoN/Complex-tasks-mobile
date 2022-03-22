using project.Models;
using project.Services;
using System.Linq;
using Xamarin.Forms;

namespace project.ViewModels
{
    /// <summary>
    /// Отображение активных задач
    /// </summary>
    public class ActiveToDoListViewModel
        : ToDoListViewModel<ToDoViewModel<ActiveToDoModel>, ActiveToDoModel>
    {
        /// <summary>
        /// Заменить на интерфейс
        /// </summary>
        private ToDoDataStore service = DependencyService.Get<ToDoDataStore>();

        /// <summary>
        /// Загружает данные
        /// </summary>
        public ActiveToDoListViewModel()
            : base()
        {
            var allItems = service.Get();

            var items = allItems.OfType<ActiveToDoModel>();

            ListName = "Активные";
            SetItmes(items.Select(x => new ToDoViewModel<ActiveToDoModel>(x)));
        }
    }
}
