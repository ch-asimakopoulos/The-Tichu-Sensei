using System.Threading.Tasks;
using TichuSensei.Core.Domain.Shared;

namespace TichuSensei.Core.Application.Shared.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
