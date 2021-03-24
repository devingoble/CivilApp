using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.ServiceLogAggregate
{
    public class ServiceLog : BaseEntity
    {
        public Guid LogId { get; private set; }
        public string StatusChange { get; private set; }
        public string Notes { get; private set; }
    }
}