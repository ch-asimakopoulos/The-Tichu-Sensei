using MediatR;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Application.Shared.Models
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent) => DomainEvent = domainEvent;

        public TDomainEvent DomainEvent { get; }
    }
}
