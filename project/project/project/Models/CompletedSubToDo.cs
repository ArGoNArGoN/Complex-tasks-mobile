using System;
using System.Collections.Generic;
using System.Text;

namespace project.Models
{
    public class CompletedSubToDo
        : SubToDoModel
    {
        public CompletedSubToDo() { }
        public CompletedSubToDo(Int32 identity)
            : base(identity) { }
        public CompletedSubToDo(SubToDoModel subTo)
            : base(subTo?.Identity ?? throw new ArgumentNullException(nameof(subTo)))
        {
            this.Title = subTo.Title;
        }

        public override Boolean Status => true;
    }
}
