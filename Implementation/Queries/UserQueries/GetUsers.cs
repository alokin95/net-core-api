using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.UserQueries;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.UserQueries
{
    public class GetUsers : IGetUsersQuery
    {
        public int Id => 24;

        public string Name => "Get users";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetUsers(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var userQuery = this.context.Users.AsQueryable();

            if (search.Firstname != null)
            {
                userQuery = userQuery.Where(u => u.FirstName.ToLower().Contains(search.Firstname.ToLower()));
            }

            if (search.Lastname != null)
            {
                userQuery = userQuery.Where(u => u.LastName.ToLower().Contains(search.Lastname.ToLower()));
            }

            if (search.Email != null)
            {
                userQuery = userQuery.Where(u => u.Email.ToLower().Contains(search.Email.ToLower()));
            }

            var users = this.mapper.Map<List<UserDto>>(userQuery.FormatForPagedResponse(search));

            return users.GeneratePagedResponse(search, userQuery);
        }
    }
}
