using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services.Entitys
{
	[Table("SubToDo")]
	internal class SubToDoEntity
		: BaseEntity
	{
		public Int32 ToDoIdentity { get; set; }
		public String Title { get; set; }
        public Int32 Status { get; set; }
    }
}
