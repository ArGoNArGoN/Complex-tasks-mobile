using project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace project.ViewModels
{
	/// <summary>
	/// Описывает коллекцию задач, связанную по критерию
	/// </summary>
	/// <typeparam name="T">Тип ViewModel</typeparam>
	/// <typeparam name="V">Тип Model</typeparam>
    public class ToDoListViewModel<T, V>
        : BaseViewModel
        where T : ToDoViewModel<V>
        where V : ToDoModel, new()
    {
		private String listName = "";

		public ToDoListViewModel()
			: base()
		{
			Items = new ObservableCollection<T>();
		}

		/// <summary>
		/// Название списка
		/// </summary>
		public String ListName
		{
			get { return listName + ":"; }
			set { listName = value + ""; OnPropertyChanged(nameof(ListName)); }
		}
		/// <summary>
		/// Коллекция задач
		/// </summary>
		public ObservableCollection<T> Items { get; }

		/// <summary>
		/// Присваивает новую коллекцию элементов
		/// </summary>
		/// <param name="enumerable">коллекция из задач</param>
		public virtual void SetItmes(IEnumerable<T> enumerable)
		{
			Items.Clear();

			if (enumerable is null)
				return;

			foreach (var item in enumerable)
				Items.Add(item);
		}

		public Int32 GetCount { get => Items.Count; }
	}
}
