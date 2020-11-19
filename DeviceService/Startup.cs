using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceService.Entities;
using DeviceService.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;

namespace DeviceService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddDbContext<DeviceDBContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
       
            services.AddScoped<IPostgresqlRepo, PostgresqlRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseRouting();
            //app.UseCors(builder => builder
            //.WithHeaders()
            //.WithMethods()
            //.WithOrigins()
            //);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<DeviceHub>("/stream");
            });

        }
    }
}
