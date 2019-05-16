using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ATM.Services;
using ATM.Repositories;
using ATM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using ATM.Core;
using ATM.Core.Framework.Encryption;
using ATMDemo.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using AutoMapper;
using ATM.Core.Entities;
using ATM.Core.DTOs;

namespace ATMDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<ATMDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Inject contect
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.InjectCoreServices();
            services.InjectDataRepositories();
            services.InjectApplicationServices();
            // Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
                {
                    options.LoginPath = "/Index";
                    options.LogoutPath = "/Logout";
                    options.AccessDeniedPath = "/AccessDenied";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                }
            );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddMvc();
            // Mapping entities to dto 
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Transaction, TransactionDTO>()).CreateMapper();
            services.AddSingleton(config);

            services.AddTransient<ILoginService, LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ATMDataContext dataContext, IHashProvider hashProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            AtmDbInitializar.Initialize(dataContext, hashProvider);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // use cookie authentication
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
