using project.Models;
using project.Models.ToDo;

using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Services.ToDoService.StateService.ModelService
{
    public class SubToDoModelService
        : ISubToDoModel
	{
		private static SubToDoModelService _service;

		private IEnumerable<IStateService<SubModel>> Services { get; }
		private SubToDoModelService(IEnumerable<IStateService<SubModel>> repositories)
		{
			this.Services = repositories ?? throw new ArgumentNullException(nameof(repositories));
		}

		/// <summary>
		/// Получение сервиса.
		/// </summary>
		/// <returns></returns>
		public static SubToDoModelService GetService()
			=> _service ?? throw new InvalidOperationException("Сервис не был инициализирован!");
		/// <summary>
		/// Инициализация.
		/// </summary>
		/// <param name="repositories"></param>
		public static void InitializeService(IEnumerable<IStateService<SubModel>> repositories)
			=> _service = _service is null
			? new SubToDoModelService(repositories)
			: throw new InvalidOperationException("Сервис уже инициализирован!");

		public static Boolean IsInit => !(_service is null);

		/// <summary>
		/// возвращает список всех зарегистрированных SubModel.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<SubModel> Get()
			=> Services.Select(x => x.Get())
			.Aggregate((x, y) => x.Concat(y));
	}
}
