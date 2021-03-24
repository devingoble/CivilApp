using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class RelatedJacket : BaseEntity
    {
        public string JacketNumber { get; private set; }

        public RelatedJacket(string jacketNumber)
        {
            JacketNumber = jacketNumber;
        }
    }
}
