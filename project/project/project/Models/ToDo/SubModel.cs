using System;

namespace project.Models.ToDo
{
    public class SubModel
        : BaseModel
    {
        private String title;

        public SubModel(IState<SubModel> state)
        {
            State = state;
        }

        public IState<SubModel> State { get; protected set; }

        public Int32 Identity { get; set; }
        public Int32 ToDoIdentity { get; set; }
        public String Title
        {
            get { return title; }
            set { title = value ?? ""; }
        }

        public void Commit()
        {
            State.Commit(this, (ob) => this.State = ob);
        }
        public void RollBack()
        {
            State.RollBack(this, (ob) => this.State = ob);
        }
    }
}