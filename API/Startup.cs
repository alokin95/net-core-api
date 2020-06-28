using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application;
using Application.Hotel.Queries;
using Application.Queries;
using Application.Queries.Chain;
using AutoMapper;
using DataAccess;
using Implementation.Logger;
using Implementation.Profiles;
using Implementation.Queries.Chain;
using Implementation.Queries.Hotel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
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

            services.AddTransient<Database>();
            //services.AddAutoMapper(typeof(Profile).GetTypeInfo().Assembly);
            services.AddAutoMapper(typeof(ChainProfile));
            services.AddTransient<ActionDispatcher>();
            services.AddTransient<IApplicationActor, AdminFakeApiActor>();
            services.AddTransient<Application.ILogger, LogToConsole>();

            services.AddTransient<IGetChainsQuery, GetChains>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
