using CoreFitness.Domain.AppUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CoreFitness.Infrastructure.Persistence.AppUsers.Configurations;

public class AppUserConfig : IEntityTypeConfiguration<AppUserEntity>
{
    public void Configure(EntityTypeBuilder<AppUserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdentityUserId)
            .IsRequired();

        builder.HasIndex(x => x.IdentityUserId)
            .IsUnique();

        builder.Property (x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        // Config below for AppUserPersonalInfo is AI generated
        builder.OwnsOne(x => x.UserPersonalInfo, personal =>
        {
            personal.Property(p => p.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FirstName");

            personal.Property(p => p.LastName)
                .HasMaxLength(50)
                .HasColumnName("LastName");

            personal.Property(p => p.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("PhoneNumber");
        });
    }
}