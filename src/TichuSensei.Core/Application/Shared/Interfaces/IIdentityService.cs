using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Shared.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<(Result, string jwtToken)> GetJWTToken(string userName, string password);
    }
}
