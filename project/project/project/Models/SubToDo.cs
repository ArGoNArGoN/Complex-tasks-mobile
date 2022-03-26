using System;

namespace project.Models
{
	public abstract class SubToDo
	{
        private String title;

		public Int32 Identity { get; private set; }

        public String Title
        {
            get { return title; }
            set { title = value ?? ""; }
        }
    }
}