using CivilApp.Core.Interfaces;
using CivilApp.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Infrastructure.Services
{
    public class JacketSequenceService : IJacketSequenceService
    {
        private readonly JacketContext _context;
        private readonly IDateTimeService _dateTimeService;

        public JacketSequenceService(JacketContext context, IDateTimeService dateTimeService)
        {
            _context = context;
            _dateTimeService = dateTimeService;
        }

        public void ResetSequence()
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "ALTER SEQUENCE JacketNumbers RESTART WITH 1";
            command.CommandType = CommandType.Text;

            _context.Database.OpenConnection();

            command.ExecuteNonQueryAsync();
        }

        public bool NeedsSequenceReset()
        {
            var needsReset = _context.Jackets.Any(j => j.JacketYear == _dateTimeService.GetCurrentDateTime().Year);

            return !needsReset;
        }
    }
}
