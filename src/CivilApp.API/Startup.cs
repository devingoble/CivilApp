using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CivilApp.Core.Configuration;
using CivilApp.Core.Interfaces;
using CivilApp.Core.Services;
using CivilApp.Infrastructure.Data;
using CivilApp.Infrastructure.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CivilApp.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CivilApp.API", Version = "v1" });
            });

            services.AddScoped(typeof(IAppLogger<>), typeof(LogAdapter<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IJacketSequenceService, JacketSequenceService>();
            services.AddDbContext<JacketContext>(options =>
            {
                options.UseSqlServer(ConnectionStringBuilder.BuildSQLConnectionString(
                    Configuration.GetValue<string>("DATABASE_SERVER"), Configuration.GetValue<string>("DATABASE"),
                    Configuration.GetValue<string>("CIVILAPP_USERNAME"),
                    Configuration.GetValue<string>("CIVILAPP_PASSWORD")));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CivilApp.API v1"));
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
