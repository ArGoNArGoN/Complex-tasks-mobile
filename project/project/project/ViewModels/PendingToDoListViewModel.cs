using project.Models;
using project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels
{
	public class PendingToDoListViewModel
        : ToDoListViewModel<PendingToDoViewModel, PendingToDoModel>
	{
        /// <summary>
        /// Заменить на интерфейс
        /// </summary>
        private ToDoDataStore service = DependencyService.Get<ToDoDataStore>();

        /// <summary>
        /// Загружает данные
        /// </summary>
        public PendingToDoListViewModel()
            : base()
        {
            ListName = "Ожидающие";
            SetItmes(service.Get().OfType<PendingToDoModel>().Select(x => new PendingToDoViewModel(x)));
        }
    }
}
