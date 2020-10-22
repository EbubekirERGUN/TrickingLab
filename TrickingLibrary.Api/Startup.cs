using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api
{
    public class Startup
    {
        private const string Allcors = "All";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<TrickStore>();

            services.AddCors(options => options.AddPolicy(Allcors,
            build=> 
            build.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod()
            ));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(Allcors);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
