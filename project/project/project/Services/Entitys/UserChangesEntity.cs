using SQLite;
using System;

namespace project.Services.Entitys
{
    [Table("UserChanges")]
    public class UserChangesEntity
        : BaseEntity
    {
        public String ModelName { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;

        /// <summary>
        /// Это поле не учитываем!
        /// </summary>
        public Int32? IDUser { get; set; }

        public Boolean IsSync { get; set; } = false
    }
}
