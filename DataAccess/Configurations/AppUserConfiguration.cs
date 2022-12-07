using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x=>x.Firstname).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Surname).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.PhoneNumber).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Password).HasMaxLength(50).IsRequired();

            builder.HasOne(x=>x.Gender).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.GenderId);
        }
    }
}