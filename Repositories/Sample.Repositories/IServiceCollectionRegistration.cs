using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Repositories.Contracts;
using Sample.Repositories.Data;
using Sample.Repositories.Impl;

namespace Sample.Repositories;

public static class IServiceCollectionRegistration
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}
