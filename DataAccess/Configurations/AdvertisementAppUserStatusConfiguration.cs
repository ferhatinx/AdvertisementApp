using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AdvertisementAppUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUserStatus> builder)
        {
            builder.Property(x=>x.Definition).HasMaxLength(300).IsRequired();
        }
    }
}