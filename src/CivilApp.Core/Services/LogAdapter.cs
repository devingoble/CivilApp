using CivilApp.Core.Interfaces;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Services
{
    public class LogAdapter<T> : IAppLogger<T>
    {
        ILogger _logger;

        public LogAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogCritical(string message, params object[] args)
        {
            _logger.LogCritical(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogCritical(Exception exception, string message, params object[] args)
        {
            _logger.LogCritical(exception, message, args);
        }

        public void LogVerbose(string message, params object[] args)
        {
            _logger.LogTrace(message, args);
        }
    }
}
