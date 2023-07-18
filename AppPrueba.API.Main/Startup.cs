using AppPrueba.API.Main.Controllers;
using AppPrueba.Application.Main;
using AppPrueba.Application.Main.Contracts;
using AppPrueba.Data.Main;
using AppPrueba.Data.Main.Contracts;

namespace AppPrueba.API.Main
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IPruebaAppService, PruebaAppService>();
            services.AddScoped<IPruebaRepository, PruebaRepository>();
            services.AddScoped<PruebaController>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
