using TichuSensei.Core.Application.Shared.Models;
using System.Threading.Tasks;

namespace TichuSensei.Core.Application.Shared.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
