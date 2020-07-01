using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.App;
using Application;
using Application.Commands.AmenityCommands;
using Application.Commands.ChainCommands;
using Application.Commands.HotelCommands;
using Application.Hotel.Queries;
using Application.Queries.AmenityQueries;
using Application.Queries.ChainQueries;
using AutoMapper;
using DataAccess;
using Implementation.Commands;
using Implementation.Commands.AmenityCommands;
using Implementation.Commands.AmmenityCommands;
using Implementation.Commands.ChainCommands;
using Implementation.Commands.HotelCommands;
using Implementation.Logger;
using Implementation.Profiles;
using Implementation.Queries.AmenityQueries;
using Implementation.Queries.ChainCommands;
using Implementation.Queries.ChainQueries;
using Implementation.Queries.Hotel;
using Implementation.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers();

            services.AddTransient<Database>();

            services.AddAutoMapper(typeof(ChainProfile), typeof(UserProfile), typeof(HotelProfile));

            #region Application defaults
            services.AddTransient<ActionDispatcher>();
            services.AddTransient<IApplicationActor, AdminFakeApiActor>();
            services.AddTransient<Application.ILogger, LogToConsole>();
            #endregion

            #region Chain
            services.AddTransient<IGetChainsQuery, GetChains>();
            services.AddTransient<IGetSingleChainQuery, GetOneChain>();
            services.AddTransient<ICreateChainCommand, CreateChain>();
            services.AddTransient<IEditChainCommand, EditChain>();
            services.AddTransient<IDeleteChainCommand, DeleteChain>();
            #endregion

            #region Hotel
            services.AddTransient<ICreateHotelCommand, CreateHotel>();
            services.AddTransient<IGetHotelsQuery, GetHotels>();
            #endregion

            #region Amenity
            services.AddTransient<IGetAmenitiesQuery, GetAmenities>();
            services.AddTransient<ICreateAmenityCommand, CreateAmenity>();
            services.AddTransient<IGetSingleAmenityQuery, GetOneAmenity>();
            services.AddTransient<IEditAmenityCommand, EditAmenity>();
            services.AddTransient<IDeleteAmenityCommand, DeleteAmenity>();
            #endregion

            #region Validations
            services.AddTransient<CreateChainValidation>();
            services.AddTransient<EditChainValidation>();
            services.AddTransient<CreateAmenityValidation>();
            services.AddTransient<EditAmenityValidation>();
            services.AddTransient<CreateHotelValidation>();
            services.AddTransient<CreateLocationValidation>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware<ExceptionHandler>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
