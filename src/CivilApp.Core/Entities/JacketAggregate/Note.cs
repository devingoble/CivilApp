using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class Note : BaseEntity
    {
        public string Text { get; private set; }
        public bool IsFlaggedDeputySafety { get; private set; }

        public Note(string text, bool isFlaggedDeputySafety)
        {
            Text = text;
            IsFlaggedDeputySafety = isFlaggedDeputySafety;
        }
    }
}
