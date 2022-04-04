using System;

namespace project.Models
{
    public abstract class SubToDoModel
    {
        private String title;

        public SubToDoModel() { }
        public SubToDoModel(int identity)
        {
            Identity = identity;
        }

        public Int32 Identity { get; private set; }
        public String Title
        {
            get { return title; }
            set { title = value ?? ""; }
        }
        public abstract Boolean Status { get; }
    }
}