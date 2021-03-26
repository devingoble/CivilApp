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
            if(filter.SortFields.Count == 0)
            {
                Query.OrderByDescending(j => j.ReceivedDate).ThenByDescending(j => j.JacketNumber);
            }
            else
            {
                Query.OrderBy(filter.SortFields);
            }

            if(filter.JacketYear != null && filter.JacketSequence != null)
            {
                Query.Where(j => j.JacketYear == filter.JacketYear && filter.JacketSequence == filter.JacketSequence);
            }

            if(filter.Defendant != null)
            {
                Query.Where(j => j.Defendants.Any(d => d.Name.Contains(filter.Defendant)));
            }

            if(filter.Plaintiff != null)
            {
                Query.Where(j => j.Plaintiffs.Any(p => p.Name.Contains(filter.Plaintiff)));
            }

            if(filter.ReceivedFrom != null)
            {
                Query.Where(j => j.ReceivedFrom.Contains(filter.ReceivedFrom));
            }
        }
    }
}
