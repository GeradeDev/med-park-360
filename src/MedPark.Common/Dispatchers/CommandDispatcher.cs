using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedPark.Common.Handlers;
using MedPark.Common.Messages;
using MedPark.Common.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace MedPark.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
        {
            try
            {
                var c = _serviceProvider.GetService<ICommandHandler<T>>();

                await c.HandleAsync(command, CorrelationContext.Empty);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
