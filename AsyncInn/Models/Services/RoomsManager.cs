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
            Room room = await GetRoom(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public Task DeleteRoomAmenity(RoomAmenities roomAmenities)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(room => room.ID == id);
        }

        public Task<List<RoomAmenities>> GetRoomAmenities()
        {
            throw new NotImplementedException();
        }

        public Task<RoomAmenities> GetRoomAmenities(int amenityID, int roomID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetRooms()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RoomAmenityPresent(int id, int amenityID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoomAmenity(RoomAmenities roomAmenities)
        {
            throw new NotImplementedException();
        }
    }
}
