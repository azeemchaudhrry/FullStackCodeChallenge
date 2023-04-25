using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Services.Contracts;
using Sample.Services.Impl;

namespace Sample.Services;

public static class IServiceCollectionRegistration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration Configuration)
    {        
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
