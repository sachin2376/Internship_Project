using System.Collections.Generic;
using IpTreatment.Entities;
using IpTreatment.Helpers;
using IpTreatment.Repository;
using IpTreatment.Repository.Interfaces;
using IpTreatment.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IpTreatment
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

            services.AddControllers();
            services.AddHttpClient();
            services.AddLogging();

            services.AddScoped<IPatients,PatientRepo>();
            services.AddScoped<ITreatmentPlans,TreatmentPlanRepo>();
            //services.AddScoped<OfferingsRepo>();
            _ = services.AddScoped<SpecialistRepo>();
            services.AddScoped<ISpecialists,SpecialistRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<PatientDBContext>();
            services.AddScoped<IOfferings,OfferingsRepo>();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IpTreatment", Version = "v1" });


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = " JWTauthentication using JWT bearer token",
                    BearerFormat = "JWT"
                });



                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new List<string>()
                    }
                  });
            });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IpTreatment v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
