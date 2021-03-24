using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class Plaintiff : BaseEntity
    {
        public string Name { get; private set; }

        public Plaintiff(string name)
        {
            Name = name;
        }
    }
}
