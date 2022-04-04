using System;

namespace project.Models
{
    public class ActiveSubToDo
        : SubToDoModel
    {
        public ActiveSubToDo() { }
        public ActiveSubToDo(Int32 identity) 
            : base(identity) { }
        public ActiveSubToDo(SubToDoModel subTo)
            : base(subTo?.Identity ?? throw new ArgumentNullException(nameof(subTo)))
        {
            this.Title = subTo.Title;
        }

        public override Boolean Status => false;
    }
}
