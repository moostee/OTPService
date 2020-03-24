using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OTP.Core.Domain.Model.Helper;
using OTP.Service.Middlewares;

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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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
