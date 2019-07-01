using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddHotel(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task AddHotelRoom(HotelRoom hotelRoom)
        {
            await _context.HotelRooms.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotelRoom(int hotelID, int roomID)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelID, roomID);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelID, int roomID)
        {
            return await _context.HotelRooms
                            .Include(r => r.Hotel)
                            .Include(r => r.Room)
                            .FirstOrDefaultAsync(m => m.RoomNumber == roomID && m.HotelID == hotelID);
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRooms
                                .Include(hotel => hotel.Hotel)
                                .Include(hotel => hotel.Room)
                                .ToListAsync();
        }

        public async Task<List<Hotel>> GetHotels(string name = null)
        {
            IQueryable<Hotel> hotels = _context.Hotels;

            if (!String.IsNullOrEmpty(name))
            {
                hotels = hotels.Where(s => s.Name.Contains(name));
            }

            return await hotels.ToListAsync();
        }

        public async Task<bool> HotelRoomIsPresent(int id, int roomNumber)
        {
            return await _context.HotelRooms.FirstOrDefaultAsync(r => r.HotelID == id && r.RoomNumber == roomNumber) != null;
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Update(hotelRoom);
            await _context.SaveChangesAsync();
        }
    }
}
