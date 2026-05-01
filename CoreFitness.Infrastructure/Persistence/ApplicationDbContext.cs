using CoreFitness.Domain.AppUsers;
using CoreFitness.Domain.MembershipPlans;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {        
    }
    
    public DbSet<AppUserEntity> AppUsers => Set<AppUserEntity>();
    public DbSet<MembershipPlanEntity> MembershipPlans => Set<MembershipPlanEntity>();
    public DbSet<MembershipPlanFeatureEntity> MembershipPlanFeatures => Set<MembershipPlanFeatureEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}