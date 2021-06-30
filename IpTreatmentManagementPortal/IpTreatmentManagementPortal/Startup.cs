using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using IpTreatmentManagementPortal.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using IpTreatmentManagementPortal.Repository;
using IpTreatmentManagementPortal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IpTreatmentManagementPortal.Repository.Interfaces;

namespace IpTreatmentManagementPortal
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

            services.AddDbContext<PatientDBContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionString:PatientDB")));

            services.AddControllersWithViews();
            
            services.AddHttpClient();
            services.AddDbContext<PatientDBContext>();
            services.AddScoped<PatientRepo>();
            services.AddScoped<OfferingsRepo>();
            services.AddScoped<InitiateClaimsRepo>();
            services.AddScoped<InsurerRepo>();
            services.AddScoped<IUserLog, UserLog>();
            


            //services.AddScoped<CustomExceptionHandler>();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
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
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            //app.UseSession();

            app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Admin}/{action=kk}/{id?}");
              });
        }
    }
}
