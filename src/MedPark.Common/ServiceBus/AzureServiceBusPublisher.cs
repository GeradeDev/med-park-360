using MedPark.Common.Messages;
using MedPark.Common.RabbitMq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace MedPark.Common.ServiceBus
{
    public class AzureServiceBusPublisher : IBusPublisher
    {
        private string _defaultNamespace;
        private QueueClient _queueClient;
        private AzureServiceBusConfig _azureServiceBusConfig;

        public AzureServiceBusPublisher(AzureServiceBusConfig azureServiceBusConfig)
        {
            _azureServiceBusConfig = azureServiceBusConfig;
            //_defaultNamespace = options.Namespace;
        }

        public Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : ICommand
        {
            throw new NotImplementedException();

            //var eventName = command.GetType().Name;
            //var jsonMessage = JsonConvert.SerializeObject(command);
            //var body = Encoding.UTF8.GetBytes(jsonMessage);

            //var message = new Message
            //{
            //    MessageId = Guid.NewGuid().ToString(),
            //    Body = body,
            //    Label = eventName,
            //};
        }

        private string GetRoutingKey<T>(T message)
        {
            var @namespace = message.GetType().GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ??
                             _defaultNamespace;
            @namespace = string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";

            return $"{@namespace}{typeof(T).Name.Underscore()}".ToLowerInvariant();
        }
    }
}
