using Ardalis.Specification;

using CivilApp.Core.Entities.JacketAggregate;
using CivilApp.Core.Specifications.Filters;

using JetBrains.Annotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Specifications
{
    public class JacketSpecification : Specification<Jacket>
    {
        public JacketSpecification(JacketFilter filter)
        {
            if(filter.SortProperties.Count == 0)
            {
                Query.OrderByDescending(q => q.ReceivedDate).ThenByDescending(q => q.JacketNumber);
            }
            else
            {
                Query.OrderBy(filter.SortProperties);
            }
        }
    }
}
