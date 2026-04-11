using CoreFitness.Application.MembershipPlans;
using CoreFitness.Infrastructure.Persistence;
using CoreFitness.Infrastructure.Persistence.MembershipPlans.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFitness.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IMembershipPlanQueries, MembershipPlanRepository>();

        return services;
    }
}