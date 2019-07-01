using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelManager : IHotelManager
    {
        private AsyncInnDbContext _context;

        public HotelManager(AsyncInnDbContext context)
        {
            _context = context;
        }
        public Task AddHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task AddHotelRoom(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotelRoom(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotel(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetHotelRoom(int hotelID, int roomNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelRoom>> GetHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotels(string name = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HotelRoomIsPresent(int id, int roomNumber)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotelRoom(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
