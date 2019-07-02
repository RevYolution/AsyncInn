using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomsManager : IRoomManager
    {
        private AsyncInnDbContext _context;

        public RoomsManager(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task AddRoomAmenityAsync(RoomAmenities roomAmenities)
        {
            _context.RoomAmenities.Add(roomAmenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            Room room = await GetRoomAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAmenityAsync(int amenityID, int roomID)
        {
            RoomAmenities roomAmenities = await GetRoomAmenitiesAsync(amenityID, roomID);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoomAsync(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(room => room.ID == id);
        }

        public async Task<List<RoomAmenities>> GetRoomAmenitiesAsync()
        {
            return await _context.RoomAmenities
                                .Include(ra => ra.Amenities)
                                .Include(r => r.Room)
                                .ToListAsync();
        }

        public async Task<RoomAmenities> GetRoomAmenitiesAsync(int amenityID, int roomID)
        {
                return await _context.RoomAmenities
                                    .Include(ra => ra.Amenities)
                                    .Include(r => r.Room)
                                    .FirstOrDefaultAsync(m => m.AmenitiesID == amenityID                && m.RoomID == roomID);

        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<bool> RoomAmenityPresentAsync(int id, int amenityID)
        {
            return await _context.RoomAmenities.FirstOrDefaultAsync(r => r.RoomID == id && r.AmenitiesID == amenityID) != null;
        }



        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public Task UpdateRoomAmenity(RoomAmenities roomAmenities)
        {
            throw new NotImplementedException();
        }
    }
}
