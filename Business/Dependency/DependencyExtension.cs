using AutoMapper;
using Business.Interfaces;
using Business.Mappings.AutoMapper;
using Business.Services;
using Business.ValidationRules;
using DataAccess.Contexts;
using DataAccess.UnitOfWork;
using Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Dependency
{
    public static class DependencyExtension
    {
        public static void Dependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementAppContext>(opt =>{
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
           
            services.AddScoped<IUow,Uow>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

           

            services.AddTransient<IValidator<AppUserCreateDto>,AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>,AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>,ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>,ProvidedServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();

            services.AddScoped<IGenderService, GenderService>();

            services.AddScoped<IAppUserService, AppUserService>();

            services.AddScoped<IAdvertisementService, AdvertisementService>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();

        }
        
        
    }
}