using System;

namespace project.Models
{
    public class ActiveSubToDo
        : SubToDo
    {
        public ActiveSubToDo() { }
        public ActiveSubToDo(SubToDo subTo)
            : base(subTo?.Identity ?? throw new ArgumentNullException(nameof(subTo)))
        {
            this.Title = subTo.Title;
        }

        public override Boolean Status => false;
    }
}
