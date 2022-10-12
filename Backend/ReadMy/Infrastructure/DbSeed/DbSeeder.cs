using Common.Authorization;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbSeed;

public class DbSeeder
{
    public static async Task SeedDatabase(IServiceProvider services, ReadMyDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ReadMyUser> userManager)
    {
        await TryCreateRolesAsync(roleManager);
        var users = await TryCreateUsersAsync(context);
        await AddRoleToUsers(userManager, users);
    }

    private static async Task TryCreateRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (await roleManager.Roles.AnyAsync())
        {
            return;
        }

        await roleManager.CreateAsync(new IdentityRole(ReadMyRoles.Admin));
        await roleManager.CreateAsync(new IdentityRole(ReadMyRoles.ProjectManager));
        await roleManager.CreateAsync(new IdentityRole(ReadMyRoles.Worker));
    }
    private static async Task<ICollection<ReadMyUser>> TryCreateUsersAsync(ReadMyDbContext context)
    {
        if (await context.Users.AnyAsync())
        {
            return new List<ReadMyUser>();
        }

        var admin = new ReadMyUser() { UserName = "admin", FullName = "Adminisztrátor" };
        var cece = new ReadMyUser() { UserName = "cece", FullName = "Czeglédi Levente" };
        var csabi = new ReadMyUser() { UserName = "csabi", FullName = "Futó Csaba" };
        var bela = new ReadMyUser() { UserName = "bela", FullName = "Kovács Béla" };
        var karoly = new ReadMyUser() { UserName = "karoly", FullName = "Kicsi Károly" };
        var andras = new ReadMyUser() { UserName = "andras", FullName = "Nagy András" };

        PasswordHasher<ReadMyUser> passwordHasher = new PasswordHasher<ReadMyUser>();
        var users = new List<ReadMyUser>
        {
            admin, 
            cece,
            csabi, 
            bela,
            karoly, 
            andras
        };

        admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");
        cece.PasswordHash = passwordHasher.HashPassword(admin, "cece");
        csabi.PasswordHash = passwordHasher.HashPassword(admin, "csabi");
        bela.PasswordHash = passwordHasher.HashPassword(admin, "bela");
        karoly.PasswordHash = passwordHasher.HashPassword(admin, "karoly");
        andras.PasswordHash = passwordHasher.HashPassword(admin, "andras");

        await context.AddRangeAsync(users);
        await context.SaveChangesAsync();
        return users;
    }

    private static async Task AddRoleToUsers(UserManager<ReadMyUser> userManager, ICollection<ReadMyUser> users)
    {
        foreach (var user in users)
        {
            if (user.UserName == "admin")
            {
                await userManager.AddToRoleAsync(user, ReadMyRoles.Admin);
            }
            else if (user.UserName == "cece" || user.UserName == "csabi")
            {
                await userManager.AddToRoleAsync(user, ReadMyRoles.ProjectManager);
            }
            else 
            {
                await userManager.AddToRoleAsync(user, ReadMyRoles.Worker);
            }
        }
    }

}
