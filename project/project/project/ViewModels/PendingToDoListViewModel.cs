using project.Models;
using project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
	public class PendingToDoListViewModel
        : ToDoListViewModel<PendingToDoViewModel, PendingToDoModel>
	{
        /// <summary>
        /// Заменить на интерфейс
        /// </summary>
        private PendingToDoRepository service = DependencyService.Get<PendingToDoRepository>();

        /// <summary>
        /// Загружает данные
        /// </summary>
        public PendingToDoListViewModel()
            : base()
        {
            ListName = "Ожидающие";
            SetItmesAsync();
        }

        public async void SetItmesAsync()
        {
            var items = await Task.Run(() => service.Get());

            SetItmes(items.Select(x => new PendingToDoViewModel(x)));
        }

        public override ICommand Refresh
            => new Command(SetItmesAsync);
    }
}
