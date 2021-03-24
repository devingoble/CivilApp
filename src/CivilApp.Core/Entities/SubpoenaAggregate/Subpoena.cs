using CivilApp.Core.Entities.Lookups;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.SubpoenaAggregate
{
    public class Subpoena : BaseEntity
    {
        public DateTime AppearanceDateTime { get; private set; }
        public string DACaseNumber { get; private set; }
        public string Defendant { get; private set; }
        public string ProsecutingAttorney { get; private set; }
        public string ServeToName { get; private set; }
        public string ServeToAddress { get; private set; }
        public string ServeToCity { get; private set; }
        public string ServeToState { get; private set; }
        public string ServeToZip { get; private set; }
        public string ServeToNotes { get; private set; }
        public SubpoenaType SubpoenaType { get; private set; }
        public Guid ServiceLogId { get; private set; }
    }
}
