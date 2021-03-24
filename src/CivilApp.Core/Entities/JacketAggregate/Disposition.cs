using CivilApp.Core.Entities.Lookups;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class Disposition : BaseEntity
    {
        public string? ServedBy { get; private set; }
        public DateTime CompletedDateTime { get; private set; }
        public DateTime ProcessDate { get; private set; }
        public string? ReturnedTo { get; private set; }
        public bool IsCorrectedAffidavit { get; private set; }
        public bool ContainsNecessaryMailings { get; private set; }
        public bool RequiresNotary { get; private set; }
        public bool DispositionPersonal { get; private set; }
        public bool DispositionAtOffice { get; private set; }
        public bool DispositionSubstitute { get; private set; }
        public bool DispositionPosted { get; private set; }
        public bool DispositionMailing { get; private set; }
        public string? AffidavitTextServedTo { get; private set; }
        public string? AffidavitTextServedAt { get; private set; }
        public string? AffidavitTextNotFound { get; private set; }
        public string? AffidavitTextAdditional { get; private set; }
    }
}
