using Newtonsoft.Json;
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
        public DateTime EndDate { get; set; }
        public DateTime DateCrate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public String Creator { get; set; }
        public String Executor { get; set; }
        public String Source { get; set; }
        public String SourceCreator { get; set; }
        public Int32 Count { get; set; }
        public String State { get; set; }

        [JsonIgnore]
        public String TypeTask { get; set; }
    }
}
