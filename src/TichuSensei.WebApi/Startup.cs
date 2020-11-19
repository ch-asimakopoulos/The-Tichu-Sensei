using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using TichuSensei.Core.Application;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Infrastructure;
using TichuSensei.Infrastructure.Persistence;
using TichuSensei.WebApi.Filters;
using TichuSensei.WebUI.Services;

namespace TichuSensei.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddSingleton<ICurrentUserService, CurrentUserService>()
                .AddSingleton<ILogger>(Log.Logger);

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 0);
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.ReportApiVersions = true;
                cfg.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Tichu Sensei API",
                            Version = "v1.0",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                            {
                                Email = "tichu.sensei@gmail.com",
                                Name = "Charalampos Asimakopoulos",
                                Url = new System.Uri("https://github.com/ch-asimakopoulos/The-Tichu-Sensei")
                            }
                        });

                    c.CustomSchemaIds(type => type.Name.EndsWith("DTO") ? type.Name.Replace("DTO", string.Empty) : type.Name);

                    //c.IncludeXmlComments
                }); 

            services.AddControllersWithViews(options =>
                    options.Filters.Add(new ApiExceptionFilterAttribute()))
                    .AddFluentValidation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Tichu Sensei API v1.0");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
