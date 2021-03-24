using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class Party : BaseEntity
    {
        public string Name { get; private set; }
        public string? PhoneNumber { get; private set; }
        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public string? AdditionalNotes { get; private set; }

        public Party(string name)
        {
            Name = name;
        }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}
