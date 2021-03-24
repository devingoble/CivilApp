using CivilApp.API.JacketEndpoints;
using CivilApp.Core.Entities.Lookups;
using CivilApp.Core.Interfaces;

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class Jacket : BaseEntity, IAggregateRoot
    {
        public string JacketNumber { get; private set; }
        public Guid GroupId { get; private set; }
        public bool ShouldNotAllowSubstituteService { get; private set; } = false;
        public bool ShouldEnterIntoLEDS { get; private set; } = false;
        public bool IsRush { get; private set; } = false;
        public string State { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string Court { get; private set; }
        public DateTime ReceivedDate { get; private set; }
        public string ReceivedFrom { get; private set; }
        public string CourtCaseNumber { get; private set; }
        public string CSPNumber { get; private set; }
        public DateTime AppearanceDateTime { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public FeeType FeeType { get; private set; }
        public int DocumentCount { get; private set; } = 0;
        public string DocumentList { get; private set; }
        private readonly List<Plaintiff> _plaintiffs = new();
        public IReadOnlyCollection<Plaintiff> Plaintiffs => _plaintiffs.AsReadOnly();
        private readonly List<Party> _defendants = new();
        public IReadOnlyCollection<Party> Defendants => _defendants.AsReadOnly();
        private readonly List<Party> _serveTo = new();
        public IReadOnlyCollection<Party> ServeTo => _serveTo.AsReadOnly();
        private readonly List<Note> _notes = new();
        public IReadOnlyCollection<Note> Notes => _notes.AsReadOnly();
        public ServiceStatus ServiceStatus { get; private set; }
        public decimal AmountRecived { get; private set; } = 0;
        public string CheckNumber { get; private set; }
        public string ReceiptNumber { get; private set; }
        public decimal RefundDue { get; private set; } = 0;
        public decimal BalanceDue { get; private set; } = 0;
        public Guid ServiceLogId { get; private set; }
        public bool HasSubpoena { get; private set; } = false;

        public Jacket(CreateJacketCommand command)
        {
            JacketNumber = command.JacketNumber;
        }

        public Jacket(CreateJacketFromSubpoenaCommand command)
        {
            JacketNumber = command.JacketNumber;

            var def = new Party(command.Defendant);
            AddDefendant(def);
            
            var serve = new Party(command.ServeToName);
            serve.AddAddress(new Address(command.ServeToNotes, command.ServeToAddress, command.ServeToCity, command.ServeToZip));
            
            AddServeTo(serve);
        }

        public void AddDefendant(Party defendant)
        {
            _defendants.Add(defendant);
        }

        public void AddServeTo(Party serveTo)
        {
            _serveTo.Add(serveTo);
        }
    }
}
