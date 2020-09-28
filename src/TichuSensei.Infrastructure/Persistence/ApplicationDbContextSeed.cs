using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using TichuSensei.Infrastructure.Identity;

namespace TichuSensei.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context) =>
            // Seed, if necessary

            await context.SaveChangesAsync();

    }
}
