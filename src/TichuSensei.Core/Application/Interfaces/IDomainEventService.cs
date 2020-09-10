using System.Threading.Tasks;
using TichuSensei.Kernel;

namespace TichuSensei.Core.Application.Shared.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
