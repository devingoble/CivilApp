using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedTimeStamp { get; private set; }
        public string ModifiedBy { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
    }
}
