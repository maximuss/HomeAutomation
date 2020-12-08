using System;
using AutoMapper;
using HomeAutomation.Database;
using HomeAutomation.Database.Repository;
using HomeAutomation.IKEA;
using HomeAutomation.IKEA.Services;
using HomeAutomation.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeAutomation.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AddNetServices(services);
            AddServices(services);
            AddRepositoryServices(services);
            AddIkeaServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private void AddNetServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            // services.AddDbContextFactory<HomeAutomationContext>(c => c.UseSqlite("Data Source=homeautomation.db"));
            services.AddDbContextFactory<HomeAutomationContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
        }
        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IkeaGatewayService>();
            services.AddScoped<JsonFilePath>();
        }

        private void AddRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<GatewayRepository>();
        }

        private void AddIkeaServices(IServiceCollection services)
        {
            services.AddScoped<Gateway>();
        }
    }
}
