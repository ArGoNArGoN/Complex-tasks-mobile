using System;

namespace project.Models
{
    /// <summary>
    /// Базовая модель задачи
    /// </summary>
	public class BaseToDoModel
		: BaseModel
	{
        private String title = "";
        private Int32 count;
        private DateTime endDate;

        public BaseToDoModel() { }

        /// <summary>
        /// Короткое название
        /// </summary>
        public String Title
        {
            get { return title; }
            set { title = value ?? ""; }
        }
        /// <summary>
        /// Количество продукции
        /// </summary>
        public Int32 Count
        {
            get { return count; }
            set { count = value; }
        }
        /// <summary>
        /// Срок, до которого нужно выполнить данную задачу
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
    }
}
