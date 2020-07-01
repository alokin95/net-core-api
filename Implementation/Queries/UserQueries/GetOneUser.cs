using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.UserQueries;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.UserQueries
{
    public class GetOneUser : IGetSingleUserQuery
    {
        public int Id => 25;

        public string Name => "Get single user";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetOneUser(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public UserDto Execute(int id)
        {
            var user = this.context.Users.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundException(id);
            }

            return this.mapper.Map<UserDto>(user);
        }
    }
}
