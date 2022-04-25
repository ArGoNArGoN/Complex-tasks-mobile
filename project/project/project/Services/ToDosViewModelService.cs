using project.Services.ToDoService;
using project.ViewModels;

using System;
using System.Linq;
using System.Collections.Generic;

namespace project.Services
{
    /// <summary>
    /// Сервис для получения всех ToDoVM
    /// </summary>
    public sealed class ToDosViewModelService
		: IGetToDoViewModel
	{
		private static ToDosViewModelService _service;

		private IEnumerable<IGetToDoViewModel> Repositories { get; }
		private ToDosViewModelService(IEnumerable<IGetToDoViewModel> repositories)
		{
			this.Repositories = repositories ?? throw new ArgumentNullException(nameof(repositories));
		}

		/// <summary>
		/// Получение сервиса
		/// </summary>
		/// <returns></returns>
		public static ToDosViewModelService GetService()
			=> _service ?? throw new InvalidOperationException("Сервис не был инициализирован!");
		/// <summary>
		/// Инициализация 
		/// </summary>
		/// <param name="repositories"></param>
		public static void InitializeService(IEnumerable<IGetToDoViewModel> repositories)
			=>_service = _service is null ? new ToDosViewModelService(repositories) : throw new InvalidOperationException("Сервис уже инициализирован!");

		/// <summary>
		/// Возвращает список Всех зарегистрированных VM в программе
		/// </summary>
		/// <returns>Список всех VM</returns>
		public IEnumerable<BaseToDoViewModel> Get()
			=> Repositories.Select(x => x.Get()).Aggregate((x, y) => x.Concat(y));
	}
}
