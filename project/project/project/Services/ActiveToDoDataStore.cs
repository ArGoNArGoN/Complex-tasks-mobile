using project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services
{
	/// <summary>
	/// Сервис для получения задач
	/// </summary>
	public class ToDoDataStore
	{
		public IEnumerable<BaseToDoModel> Get()
        {
			return new List<BaseToDoModel>
			{
				new ActiveToDoModel()
				{
					Title = "Книги",
					Count = 400,
					EndDate = DateTime.Now + new TimeSpan(23, 0, 0)
                },
				new ActiveToDoModel()
				{
					Title = "Брошюры",
					Count = 120,
					EndDate = DateTime.Now + new TimeSpan(1, 5, 0, 0)
				},
				new ActiveToDoModel()
				{
					Title = "Брошюры",
					Count = 120,
					EndDate = DateTime.Now + new TimeSpan(1, 5, 0, 0)
				},
			};
        }
	}
}
