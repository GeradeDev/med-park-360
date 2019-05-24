using MedPark.Common.Messages;
using MedPark.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedPark.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
