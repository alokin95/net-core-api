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
using Application.Commands.RoomCommands;
using Application.Commands.UserCommands;
using Application.Hotel.Queries;
using Application.Queries.AmenityQueries;
using Application.Queries.ChainQueries;
using Application.Queries.HotelQueries;
using Application.Queries.LogQueries;
using Application.Queries.RoomQueries;
using Application.Queries.UserQueries;
using AutoMapper;
using DataAccess;
using Implementation.Commands;
using Implementation.Commands.AmenityCommands;
using Implementation.Commands.AmmenityCommands;
using Implementation.Commands.ChainCommands;
using Implementation.Commands.HotelCommands;
using Implementation.Commands.RoomCommands;
using Implementation.Commands.UserCommands;
using Implementation.Logger;
using Implementation.Profiles;
using Implementation.Queries;
using Implementation.Queries.AmenityQueries;
using Implementation.Queries.ChainCommands;
using Implementation.Queries.ChainQueries;
using Implementation.Queries.Hotel;
using Implementation.Queries.HotelQueries;
using Implementation.Queries.LogQueries;
using Implementation.Queries.RoomQueries;
using Implementation.Queries.UserQueries;
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
            services.AddTransient<Application.ILogger, LogToDatabase>();
            services.AddTransient<IGetLogsQuery, GetLogs>();
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
            services.AddTransient<IGetSingleHotelQuery, GetOneHotel>();
            services.AddTransient<IEditHotelCommand, EditHotel>();
            services.AddTransient<IDeleteHotelCommand, DeleteHotel>();
            #endregion

            #region Amenity
            services.AddTransient<IGetAmenitiesQuery, GetAmenities>();
            services.AddTransient<ICreateAmenityCommand, CreateAmenity>();
            services.AddTransient<IGetSingleAmenityQuery, GetOneAmenity>();
            services.AddTransient<IEditAmenityCommand, EditAmenity>();
            services.AddTransient<IDeleteAmenityCommand, DeleteAmenity>();
            #endregion

            #region Room
            services.AddTransient<ICreateRoomCommand, CreateRoom>();
            services.AddTransient<IGetRoomsQuery, GetRooms>();
            services.AddTransient<IGetSingleRoomQuery, GetOneRoom>();
            services.AddTransient<IEditRoomCommand, EditRoom>();
            services.AddTransient<IDeleteRoomCommand, DeleteRoom>();
            #endregion

            #region User
            services.AddTransient<ICreateUserCommand, CreateUser>();
            services.AddTransient<IGetUsersQuery, GetUsers>();
            services.AddTransient<IGetSingleUserQuery, GetOneUser>();
            services.AddTransient<IEditUserCommand, EditUser>();
            services.AddTransient<IDeleteUserCommand, DeleteUser>();
            #endregion

            #region Validations
            services.AddTransient<CreateChainValidation>();
            services.AddTransient<EditChainValidation>();
            services.AddTransient<CreateAmenityValidation>();
            services.AddTransient<EditAmenityValidation>();
            services.AddTransient<CreateHotelValidation>();
            services.AddTransient<CreateLocationValidation>();
            services.AddTransient<EditHotelValidation>();
            services.AddTransient<EditLocationValidation>();
            services.AddTransient<CreateRoomValidation>();
            services.AddTransient<EditRoomValidation>();
            services.AddTransient<CreateUserValidation>();
            services.AddTransient<EditUserValidation>();
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
