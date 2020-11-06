using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Protoss.Application.Contracts;

namespace Protoss.Config
{
    public class CommandHandlerResolver : ICommandHandlerResolver
    {
        private readonly IComponentContext _context;

        public CommandHandlerResolver(IComponentContext context)
        {
            _context = context;
        }
        public IEnumerable<ICommandHandler<T>> ResolveHandlers<T>(T command) where T : ICommand
        {
           return _context.Resolve<IEnumerable<ICommandHandler<T>>>();
        }
    }
}
