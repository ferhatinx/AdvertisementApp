using DataAccess.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class AdvertisementAppContext : DbContext
    {
        public AdvertisementAppContext(DbContextOptions<AdvertisementAppContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
        }
        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }

        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
    }
}