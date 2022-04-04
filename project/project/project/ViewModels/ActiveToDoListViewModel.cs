using project.Models;
using project.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
    /// <summary>
    /// Отображение активных задач
    /// </summary>
    public class ActiveToDoListViewModel
        : ToDoListViewModel<ActiveToDoViewModel, ActiveToDoModel>
    {
        /// <summary>
        /// Заменить на интерфейс
        /// </summary>
        private ActiveToDoRepository service = DependencyService.Get<ActiveToDoRepository>();

        /// <summary>
        /// Загружает данные
        /// </summary>
        public ActiveToDoListViewModel()
            : base()
        {
            ListName = "Активные";
            SetItmesAsync();
        }

        public async void SetItmesAsync()
        {
            var items = await Task.Run(() => service.Get());

            SetItmes(items.Select(x => new ActiveToDoViewModel(x)));
        }

        public override ICommand Refresh
            => new Command(SetItmesAsync);
    }
}
