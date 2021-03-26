using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Specifications.Filters
{
    public record JacketFilter(int? JacketYear, int? JacketSequence, string? Defendant, string? Plaintiff, string? ReceivedFrom, int Page, int PageSize, List<SortField> SortFields) : 
        BaseFilter(Page, PageSize, SortFields);
}
