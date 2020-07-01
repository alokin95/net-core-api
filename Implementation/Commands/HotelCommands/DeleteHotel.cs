using Application.Commands.HotelCommands;
using Application.Exceptions;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.HotelCommands
{
    public class DeleteHotel : IDeleteHotelCommand
    {
        public int Id => 17;

        public string Name => "Delete a hotel";

        private readonly Database context;

        public DeleteHotel(Database context)
        {
            this.context = context;
        }

        public void Execute(int id)
        {
            var hotel = this.context.Hotels.Find(id);

            if (hotel == null)
            {
                throw new EntityNotFoundException(id);
            }

            hotel.Delete();

            this.context.SaveChanges();
        }
    }
}
