using MedPark.Common.RabbitMq;
using MedPark.Common.Messages;
using System.Threading.Tasks;

namespace MedPark.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}