﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public async Task<string> GetUserNameAsync(string userId)
        {
            ApplicationUser user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            ApplicationUser user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<(Result, string)> GetJWTToken(string userName, string password)
        {
            ApplicationUser user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);
            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, password);
            if(isAuthenticated)
            {
                return (Result.Success(), "asa");
                    
            }

            return (Result.Success(), string.Empty);


        }
    }
}
