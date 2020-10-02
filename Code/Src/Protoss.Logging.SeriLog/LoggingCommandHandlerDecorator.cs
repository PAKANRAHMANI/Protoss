using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Protoss.Application.Contracts;
using Protoss.Core.Logging;

namespace Protoss.Logging.SeriLog
{
    public class LoggingCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly ILogger _logger;

        public LoggingCommandHandlerDecorator(ICommandHandler<T> commandHandler, ILogger logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task Handle(T command)
        {
            _logger.Write("Command is : {@Command}", LogLevel.Information, command);
            await _commandHandler.Handle(command);
        }
    }
}
