using System.Threading;
using System.Threading.Tasks;

namespace TichuSensei.Core.Application.Shared.Interfaces
{
    public interface IApplicationDbContext
    {

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
