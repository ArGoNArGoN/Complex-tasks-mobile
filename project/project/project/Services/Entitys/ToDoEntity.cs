using SQLite;
using System;

namespace project.Services.Entitys
{
    [Table("ToDo")]
    internal class ToDoEntity
        : BaseEntity
    {
        [MaxLength(100)]
        public String Title { get; set; }
        [MaxLength(5000)]
        public String Description { get; set; }
        public DateTime EndTime { get; set; }
        public Int32 Count { get; set; }
        public Int32 Status { get; set; }
    }
}
