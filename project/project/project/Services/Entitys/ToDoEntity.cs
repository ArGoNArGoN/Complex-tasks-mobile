using SQLite;
using System;

namespace project.Services.Entitys
{
    [Table("ToDo")]
    public class ToDoEntity
        : BaseEntity
    {
        [MaxLength(100)]
        public String Title { get; set; }
        [MaxLength(5000)]
        public String Description { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DateCrate { get; set; }
        public String Creator { get; set; }
        public String Executor { get; set; }
        public Int32 Count { get; set; }
        public String State { get; set; }
        public String TypeTask { get; set; }
    }
}
