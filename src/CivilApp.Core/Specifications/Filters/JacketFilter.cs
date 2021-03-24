using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Specifications.Filters
{
    public record JacketFilter(string? JacketNumber, string? Defendant, string? Plaintiff, string ReceivedFrom, int Page, int PageSize) : 
        BaseFilter(Page, PageSize);
}
