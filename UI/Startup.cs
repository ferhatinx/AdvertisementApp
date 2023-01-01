using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dependency;
using Business.Helpers;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.Mappings.AutoMapper;
using UI.Models;
using UI.ValidationRules;

namespace UI
{
    public class Startup
    {
        public IConfiguration Configuration {get; set;}
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
                services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

                services.Dependencies(Configuration);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>{
                opt.Cookie.Name = "AdvertisementCookie";
                opt.Cookie.HttpOnly= true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan= TimeSpan.FromDays(5);
                opt.LoginPath = new PathString("/Account/SignIn");
                opt.LogoutPath = new PathString("/Account/LogOut");
                opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });

            services.AddControllersWithViews();


            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
