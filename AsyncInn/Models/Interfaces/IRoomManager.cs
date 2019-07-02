using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        /// <summary>
        /// Add a room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        Task AddRoomAsync(Room room);

        /// <summary>
        /// Delete a room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        Task DeleteRoomAsync(int id);

        /// <summary>
        /// Update a room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        Task UpdateRoomAsync(Room room);

        /// <summary>
        /// Get a list of rooms
        /// </summary>
        /// <returns></returns>
        Task<List<Room>> GetRoomsAsync();

        /// <summary>
        /// Get a single room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Room> GetRoomAsync(int? id);

        /// <summary>
        /// Check to see if an amenity is associated with a room
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aminetyID"></param>
        /// <returns></returns>
        Task<bool> RoomAmenityPresentAsync(int id, int amenityID);


        /// <summary>
        /// Add a new room amenity
        /// </summary>
        /// <param name="roomAmenities"></param>
        /// <returns></returns>
        Task AddRoomAmenityAsync(RoomAmenities roomAmenities);

        /// <summary>
        /// Delete a room amenity
        /// </summary>
        /// <param name="roomAmenities"></param>
        /// <returns></returns>
        Task DeleteRoomAmenityAsync(int amenityID, int roomID);

        /// <summary>
        /// Update a room amenity
        /// </summary>
        /// <param name="roomAmenities"></param>
        /// <returns></returns>
        Task UpdateRoomAmenity(RoomAmenities roomAmenities);

        /// <summary>
        /// Get a list of all room amenities
        /// </summary>
        /// <returns></returns>
        Task<List<RoomAmenities>> GetRoomAmenitiesAsync();

        /// <summary>
        /// Get a single amenity
        /// </summary>
        /// <param name="amenityID"></param>
        /// <param name="roomID"></param>
        /// <returns></returns>
        Task<RoomAmenities> GetRoomAmenitiesAsync(int amenityID, int roomID);
    }
}
