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
            var mapperConfiguration = new MapperConfiguration(opt=>
            {
                opt.AddProfile(new ProvidedServiceMapper());

            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUow,Uow>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>,ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>,ProvidedServiceUpdateDtoValidator>();


            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();

        }
        
        
    }
}