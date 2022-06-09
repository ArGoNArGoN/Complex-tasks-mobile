using project.Models.ToDo;

using System.Collections.Generic;
using System.Linq;
using System;
using project.ViewModels;

namespace project.Services.ToDoService.StateService.ModelService
{
	public class ToDoModelService
		: IGetToDoModel<ToDoModel>, ISaveToDoModel<ToDoModel>
	{
		private static ToDoModelService _service;

		private IEnumerable<IStateService<ToDoModel>> Services { get; }
		private ToDoModelService(IEnumerable<IStateService<ToDoModel>> repositories)
		{
			this.Services = repositories ?? throw new ArgumentNullException(nameof(repositories));
		}

		/// <summary>
		/// Получение сервиса.
		/// </summary>
		/// <returns></returns>
		public static ToDoModelService GetService()
			=> _service ?? throw new InvalidOperationException("Сервис не был инициализирован!");

		public ToDoModel Get(int identity)
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
        public static void InitializeService(IEnumerable<IStateService<ToDoModel>> repositories)
			=> _service = _service is null 
			? new ToDoModelService(repositories)
			: throw new InvalidOperationException("Сервис уже инициализирован!");

		public static Boolean IsInit => !(_service is null);

		/// <summary>
		/// возвращает список всех зарегистрированных ToDoModel.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<ToDoModel> Get()
			=> Services.Select(x => x.Get())
			.Aggregate((x, y) => x.Concat(y));

        public void Save(ToDoModel model)
        {

		}
    }
}
