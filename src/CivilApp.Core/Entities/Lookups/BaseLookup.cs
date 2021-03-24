using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Entities.Lookups
{
    public class BaseLookup
    {
        public int Id { get; private set; }
        public string DisplayValue { get; private set; }
        public string Description { get; private set; }
        public int SortOrder { get; private set; }
        public bool IsActive { get; private set; }
    }
}
