using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(x=> new{ x.AdvertisementId,x.AppUserId}).IsUnique();

            builder.Property(x=>x.CvPath).HasMaxLength(500).IsRequired();
            builder.HasOne(x=>x.Advertisement).WithMany(x=>x.AdvertisementAppUser).HasForeignKey(x=>x.AdvertisementId);
            builder.HasOne(x=>x.AppUser).WithMany(x=>x.AdvertisementAppUser).HasForeignKey(x=>x.AppUserId);
            builder.HasOne(x=>x.AdvertisementAppUserStatus).WithMany(x=>x.AdvertisementAppUser).HasForeignKey(x=>x.AdvertisementAppUserStatusId);
            builder.HasOne(x=>x.MilitaryStatus).WithMany(x=>x.AdvertisementAppUser).HasForeignKey(x=>x.MilitaryStatusId);
        }
    }
}