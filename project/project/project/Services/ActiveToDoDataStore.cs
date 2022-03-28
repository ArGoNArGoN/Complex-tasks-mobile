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
				new ActiveToDoModel(new List<SubToDo>() { new ActiveSubToDo() { Title="Написать что-то!" } })
				{
					Title = "Книги",
					Count = 400,
					EndDate = DateTime.Now - new TimeSpan(23, 0, 0),
                },
				new ActiveToDoModel()
				{
					Title = "Брошюры",
					Count = 120,
					EndDate = DateTime.Now + new TimeSpan(0, 3, 0, 0)
				},

				new PendingToDoModel(new List<SubToDo>() { new ActiveSubToDo() { Title="Написать что-то!" }, new ActiveSubToDo() { Title="Написать что-то!" }, new ActiveSubToDo() { Title="Написать что-то!" }, new CompletedSubToDo() { Title="Написать что-то!" }, new CompletedSubToDo() { Title="Написать что-то!" }, new CompletedSubToDo() { Title="Написать что-то!" } })
                {
					Title = "Стенды",
					Count = 3,
					EndDate = DateTime.Now + new TimeSpan(0, 3, 0, 0)
				},
				new PendingToDoModel(new List<SubToDo>() { new ActiveSubToDo() { Title="Написать что-то!" }, new CompletedSubToDo() { Title="Написать что-то!" } })
				{
					Title = "Крепежи",
					Count = 132,
					EndDate = DateTime.Now + new TimeSpan(3, 10, 0, 0)
				},
				new PendingToDoModel()
				{
					Title = "Рамки",
					Count = 100,
					EndDate = DateTime.Now + new TimeSpan(1, 3, 0, 0)
				},
			};
        }
	}
}
