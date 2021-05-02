using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppDI.Data;
using WebAppDI.Services;

namespace WebAppDI
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
            services.AddDbContext<LtContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("LearningTogether")));

            services.AddAutoMapper(this.GetType().Assembly);

            services.AddControllersWithViews();

            services.AddHttpClient("client1", cfg =>
            {
                cfg.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("*/*"));
                cfg.Timeout = TimeSpan.FromSeconds(30);
            })
                .ConfigurePrimaryHttpMessageHandler(conf =>
                {
                    return new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.None };
                });

            services.AddHttpClient("client2", cfg =>
            {
                cfg.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                cfg.Timeout = TimeSpan.FromSeconds(120);
            });

            if (true)
            {
                services.AddSingleton<IInitials, Initials>();
            }
            else
            {
                services.AddSingleton<IInitials, Initials>();
            }
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
