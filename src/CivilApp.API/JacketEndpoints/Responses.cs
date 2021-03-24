using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivilApp.API.JacketEndpoints
{
    public record BaseResponse(int JacketCount, int CurrentPage, int PageCount);

    public record JacketResponse(string JacketNumber, DateTime ReceivedDate, string ReceivedFrom, string Defendant, string ServeTo,
        string Status, DateTime? ServiceDate, string ActualServeTo, int JacketCount, int CurrentPage, int PageCount) : BaseResponse(JacketCount, CurrentPage, PageCount);
}