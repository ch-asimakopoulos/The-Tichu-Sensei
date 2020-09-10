using TichuSensei.Core.Application.Shared.Models;
using TichuSensei.Kernel;
using MediatR;
using Serilog;
using System;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public DomainEventService(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            _logger.Information("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}