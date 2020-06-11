using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using OTP.Core.Common;
using OTP.Core.Data;
using OTP.Core.Domain;
using OTP.Core.Domain.Model.Helper;
using OTP.Core.Logic;
using OTP.Service.Middlewares;
using SkarpaUMS_Core.Common;

namespace OTPService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static string connectionString;
        public static Dictionary<string, string> MySettings { get; private set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("X-Pagination", "www-authenticate")
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(86400));
                });
            });

            MySettings = Configuration.GetSection("MySettings").GetChildren()
                 .ToDictionary(x => x.Key, x => x.Value);
            Settings.Initiate(MySettings);
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.AddHttpContextAccessor();
            services.AddDbContext<OTPContext>(options =>
                    options.UseSqlServer(Constants.DB_CONN));

            //Add swagger
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo() { Title = "OTP Service", Version = "V1" });
            });

            AutoMapperConfig.RegisterMappings();
            OTPPoco.Setup(Constants.DB_CONN);

            services.AddTransient<IFactoryModule, FactoryModule>();
            services.AddTransient<ILogicModule, LogicModule>();
            services.AddTransient<IDataModule, DataModule>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // add swagger
            var swaggerOptions = new OTP.Core.Domain.Model.Helper.SwaggerOptions();
            Configuration.GetSection(nameof(Swashbuckle.AspNetCore.Swagger.SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseClientSecretMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
