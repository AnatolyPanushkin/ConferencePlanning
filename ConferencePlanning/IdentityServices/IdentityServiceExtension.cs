using ConferencePlanning.Data;
using ConferencePlanning.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ConferencePlanning.IdentityServices;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ConferencePlanningContext>()
            .AddSignInManager<SignInManager<User>>();
        
        services.AddAuthentication();

        return services;
    }
}