using MedPark.Common.Messages;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, MedParkException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, MedParkException, IRejectedEvent> onError = null)
            where TEvent : IEvent;
    }
}
