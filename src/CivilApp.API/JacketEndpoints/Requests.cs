using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.API.JacketEndpoints
{
    public record BaseRequest(int Page, int PageSize);

    public record JacketRequest(string? JacketNumber, string? Defendant, string? Plaintiff, string? ReceivedFrom, string? ServeTo, 
        string? ServeToAddress, string? CourtCaseNumber, string? CSPNumber, int Page, int PageSize) :
        BaseRequest(Page, PageSize);
}