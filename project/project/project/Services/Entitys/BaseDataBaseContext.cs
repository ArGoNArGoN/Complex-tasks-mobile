using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services.Entitys
{
	public class BaseDataBaseContext
	{
		protected SQLiteConnection connection;

		protected BaseDataBaseContext(SQLiteConnection connection)
        {
			this.connection = connection;
        }
	}
}
