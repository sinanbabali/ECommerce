using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ECommerce.Persistence;
using ECommerce.Persistence.Context;
using FluentValidation.AspNetCore;
using ECommerce.Domain.Entities;
using ECommerce.Services.Implementations;
using ECommerce.Services.Interfaces;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ECommerce.Api
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
            services.AddPersistenceRegistration(Configuration);
            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .ToDictionary(
                            e => e.Key,
                            e => e.Value.Errors.Select(x => x.ErrorMessage).ToArray()
                        );

                    var response = new ServiceResponse
                    {
                        Status = false,
                        Message = "One or more validation errors occurred.",
                        Optional = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });

            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IProductService, ProductService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.Api v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}