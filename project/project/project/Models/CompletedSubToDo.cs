using System;
using System.Collections.Generic;
using System.Text;

namespace project.Models
{
    public class CompletedSubToDo
        : SubToDo
    {
        public CompletedSubToDo() { }
        public CompletedSubToDo(SubToDo subTo)
            : base(subTo?.Identity ?? throw new ArgumentNullException(nameof(subTo)))
        {
            this.Title = subTo.Title;
        }

        public override Boolean Status => true;
    }
}
