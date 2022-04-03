using System;

namespace project.Models
{
    public abstract class SubToDo
    {
        private String title;

        protected SubToDo() { }

        protected SubToDo(int identity)
        {
            Identity = identity;
        }

        public Int32 Identity { get; private set; }

        public abstract Boolean Status { get; }

        public String Title
        {
            get { return title; }
            set { title = value ?? ""; }
        }
    }
}