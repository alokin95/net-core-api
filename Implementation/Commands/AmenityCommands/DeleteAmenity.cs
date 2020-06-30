using Application.Commands.AmenityCommands;
using Application.Exceptions;
using DataAccess;
using Domain.Entity;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.AmenityCommands
{
    public class DeleteAmenity : IDeleteAmenityCommand
    {
        public int Id => 15;

        public string Name => "Delete amenity";

        private readonly Database context;

        public DeleteAmenity(Database context)
        {
            this.context = context;
        }

        public void Execute(int id)
        {
            var amenity = this.context.Amenities.Find(id);

            if (amenity == null)
            {
                throw new EntityNotFoundException(id);
            }

            amenity.Delete();

            this.context.SaveChanges();
        }
    }
}
