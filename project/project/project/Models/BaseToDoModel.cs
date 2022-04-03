using System;

namespace project.Models
{
	/// <summary>
	/// Базовая модель задачи
	/// </summary>
	public class BaseToDoModel
		: BaseModel
	{
		private Int32 id = 0;
		protected String title = "";
		protected Int32 count;
		protected DateTime endDate;

		public BaseToDoModel() { }

		/// <summary>
		/// Идентификатор
		/// </summary>
		public Int32 Identity 
		{
			get => id;
			set => id = value > 0 ? value
				: throw new ArgumentException("value < 0");
		}
		/// <summary>
		/// Короткое название
		/// </summary>
		public virtual String Title
		{
			get { return title; }
			set { title = value ?? ""; }
		}
		/// <summary>
		/// Количество продукции
		/// </summary>
		public virtual Int32 Count
		{
			get { return count; }
			set { count = value; }
		}
		/// <summary>
		/// Срок, до которого нужно выполнить данную задачу
		/// </summary>
		public virtual DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
	}
}
