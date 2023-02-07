using ConferencePlanning.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ConferencePlanning.Data;

public class Seed
{
    public static async Task SeedData(UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var users = new List<User>
            {
                new User {DisplayName = "Jhon", UserName = "Jhon", Email = "jhon@mail.ru",Bio = "Jhon"},
                new User {DisplayName = "Bob", UserName = "Bob", Email = "bob@mail.ru",Bio = "Jhon"},
                new User {DisplayName = "Tom", UserName = "Tom", Email = "tom@mail.ru",Bio = "Jhon"}
            };

            foreach (var user in users)
            {
               await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}