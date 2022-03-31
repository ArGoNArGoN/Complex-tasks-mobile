﻿using project.Models;
using project.Services;
using System.Linq;
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
        private ToDoDataStore service = DependencyService.Get<ToDoDataStore>();

        /// <summary>
        /// Загружает данные
        /// </summary>
        public ActiveToDoListViewModel()
            : base()
        {
            ListName = "Активные";
            SetItmes(service.Get().OfType<ActiveToDoModel>().Select(x => new ActiveToDoViewModel(x)));
        }
    }
}
