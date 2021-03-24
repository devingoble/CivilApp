using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.JacketAggregate
{
    public class Address : BaseEntity
    {
        public string? Label { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string Zip { get; private set; }
        public bool IsEmployer { get; private set; }
        public bool IsPossible { get; private set; }

        public Address(string streetAddress, string city, string zip, string? label)
        {
            Label = label;
            StreetAddress = streetAddress;
            City = city;
            Zip = zip;
        }
    }
}
