using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivilApp.API.JacketEndpoints
{
    public record CreateJacketCommand(string JacketNumber);

    public record CreateJacketFromSubpoenaCommand(string JacketNumber, DateTime AppearanceDateTime, string Defendant, string ServeToName, string ServeToAddress, string ServeToCity, 
        string ServeToState, string ServeToZip, string ServeToNotes, string SubpoenaType, Guid ServiceLogId);
}
