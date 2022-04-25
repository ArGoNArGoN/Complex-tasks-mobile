using project.ViewModels;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace project.Views.DataTemplateSelectors
{
	public class ToDoItemDataTemplateSelector
		: DataTemplateSelector
	{
		public DataTemplate ToDoTemplate { get; set; }
		public DataTemplate ToDoSubsTemplate { get; set; }
		public DataTemplate BaseToDoTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
            DataTemplate template;

            if (item is ToDoViewModel)
			{
				template = ToDoTemplate;
			}
			else if (item is ToDoSubsViewModel)
			{
				template = ToDoSubsTemplate;
			}
			else if (item is BaseToDoViewModel)
			{
				Log.Warning("WARRNING", "Не найден шаблон для объекта: " + ((BaseToDoViewModel)item));
				template = BaseToDoTemplate;
			}
			else
			{
				throw new InvalidCastException("item is not BaseToDoViewModel");
			}

			return template;
		}
	}
}
