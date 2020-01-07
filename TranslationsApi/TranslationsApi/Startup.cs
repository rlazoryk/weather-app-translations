using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TranslationsApi.Core;
using TranslationsApi.Core.Abstractions;
using TranslationsApi.Core.Abstractions.Services;
using TranslationsApi.DAL;
using TranslationsApi.Extensions;
using TranslationsApi.Services.Services;

namespace TranslationsApi
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(ModelMapper));
            //var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new ModelMapper()));


            var connection = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<TranslationsApiContext>(e => e.UseSqlServer(connection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITranslationService, TranslationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IUnitOfWork unitOfWork, ILoggerFactory loggerFactory)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowMyOrigin");

            SeedData.Initialize(unitOfWork);

            var logger = loggerFactory.CreateLogger("Errors");
            app.ConfigureExceptionHandler(logger);

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
