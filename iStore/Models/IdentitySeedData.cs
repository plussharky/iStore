using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iStore.Models;

public class IdentitySeedData
{
    private const string adminUser = "Admin";
    private const string adminPassword = "Admin";

    public static async Task EnsurePopulated(IApplicationBuilder app)
    {

        AppIdentityDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<AppIdentityDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        UserManager<IdentityUser> userManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

        IdentityUser? user = await userManager.FindByNameAsync(adminUser);
        if (user == null)
        {
            user = new IdentityUser(adminUser);
            user.Email = "plusharky@yandex.ru";
            user.PhoneNumber = "+1 (234) 567-89-00";
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
            Console.WriteLine(await userManager.CreateAsync(user, adminPassword));
        }
    }
}