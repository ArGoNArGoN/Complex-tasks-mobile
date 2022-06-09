using project.Models.ToDo;

using System.Collections.Generic;
using System.Linq;
using System;

namespace project.Services.ToDoService.StateService.ModelService
{
	/// <summary>
	/// Сервис для получения задач с подзадачами
	/// </summary>
    public class ToDoSubsModelService
		: IGetToDoModel<ToDoSubsModel>
	{
		private static ToDoSubsModelService _service;

		private IEnumerable<IStateService<ToDoSubsModel>> Services { get; }
		private ToDoSubsModelService(IEnumerable<IStateService<ToDoSubsModel>> repositories)
		{
			this.Services = repositories;
		}

		/// <summary>
		/// Получение сервиса.
		/// </summary>
		/// <returns></returns>
		public static ToDoSubsModelService GetService()
			=> _service ?? throw new InvalidOperationException("Сервис не был инициализирован!");

        internal ToDoSubsModel Get(int identity)
		{
			foreach (var item in Services)
			{
				var model = item.Get(identity);

				if (!(model is null))
					return model;
			}
			return null;
		}

		/// <summary>
		/// Инициализация.
		/// </summary>
		/// <param name="repositories"></param>
		public static void InitializeService(IEnumerable<IStateService<ToDoSubsModel>> repositories)
			=> _service = _service is null
			? new ToDoSubsModelService(repositories)
			: throw new InvalidOperationException("Сервис уже инициализирован!");

		public static Boolean IsInit => !(_service is null);

		/// <summary>
		/// возвращает список всех зарегистрированных ToDoModel.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<ToDoSubsModel> Get()
			=> Services.Select(x => x.Get())
			.Aggregate((x, y) => x.Concat(y));
    }
}
