using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x=> new { x.AppRoleId,x.AppUserId}).IsUnique();

            builder.HasOne(x=>x.AppUser).WithMany(x=>x.AppUserRoles).HasForeignKey(x=>x.AppUserId);
            builder.HasOne(x=>x.AppRole).WithMany(x=>x.AppUserRoles).HasForeignKey(x=>x.AppRoleId);
        }
    }
}