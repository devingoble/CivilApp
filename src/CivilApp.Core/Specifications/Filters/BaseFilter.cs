using Ardalis.Specification;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Specifications.Filters
{
    public record BaseFilter(int Page, int PageSize, List<SortField> SortFields);

    public record SortField(string FieldName, OrderTypeEnum SortType);
}
