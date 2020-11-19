using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TichuSensei.Kernel.BaseModels
{

    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }

    public abstract class DomainEvent
    {
        protected DomainEvent() => DateOccurred = DateTimeOffset.UtcNow;

        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

        public static Func<IMediator> Mediator { get; set; }
        public static async Task Raise<T>(T args) where T : INotification
        {
            IMediator mediator = Mediator.Invoke();
            await mediator.Publish<T>(args);
        }
    }
}
