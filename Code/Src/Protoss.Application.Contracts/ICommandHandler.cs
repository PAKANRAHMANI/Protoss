﻿using System.Threading.Tasks;

namespace Protoss.Application.Contracts
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}