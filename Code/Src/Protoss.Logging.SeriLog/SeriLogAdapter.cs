using System;
using Serilog.Events;
using Protoss.Core.Logging;

namespace Protoss.Logging.SeriLog
{
    public class SeriLogAdapter : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SeriLogAdapter(Serilog.ILogger logger)
        {
            _logger = logger;
        }
        public void Write(string message, LogLevel level)
        {
            _logger.Write((LogEventLevel)level, message);
        }

        public void Write(string template, LogLevel level, params object[] parameters)
        {
            _logger.Write((LogEventLevel)level, template, parameters);
        }

        public void WriteException(Exception exception)
        {
            _logger.Error(exception, "error");
        }
    }
}
