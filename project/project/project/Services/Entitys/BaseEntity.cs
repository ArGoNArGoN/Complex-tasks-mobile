using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services.Entitys
{
    internal abstract class BaseEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public Int32 Identity { get; set; }
    }
}
