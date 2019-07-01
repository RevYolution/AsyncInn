using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        /// <summary>
        /// Add a hotel 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        Task AddHotel(Hotel hotel);

        /// <summary>
        /// Delete a hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        Task DeleteHotel(int id);

        /// <summary>
        /// Update hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        Task UpdateHotel(Hotel hotel);

        /// <summary>
        /// Gets a list of all hotels 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<List<Hotel>> GetHotels(string name = null);

        /// <summary>
        /// Gets an individual hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hotel> GetHotel(int id);

        /// <summary>
        /// Checks if a hotel room exists. 
        /// </summary>
        /// <param name="id">Hotel room id</param>
        /// <param name="roomNumber">Room number to check</param>
        /// <returns>True/False if room present</returns>
        Task<bool> HotelRoomIsPresent(int id, int roomNumber);

        /// <summary>
        /// Adds a hotel room to a hotel
        /// </summary>
        /// <param name="hotelRoom"></param>
        /// <returns></returns>
        Task AddHotelRoom(HotelRoom hotelRoom);

        /// <summary>
        /// Deletes a hotel room from a hotel 
        /// </summary>
        /// <param name="hotelRoom"></param>
        /// <returns></returns>
        Task DeleteHotelRoom(int hotelID, int roomID);

        /// <summary>
        /// Updates a hotel room in a hotel. 
        /// </summary>
        /// <param name="hotelRoom"></param>
        /// <returns></returns>
        Task UpdateHotelRoom(HotelRoom hotelRoom);

        /// <summary>
        /// Gets hotel rooms 
        /// </summary>
        /// <returns></returns>
        Task<List<HotelRoom>> GetHotelRooms();

        /// <summary>
        /// Gets a single room. 
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        Task<HotelRoom> GetHotelRoom(int hotelID, int roomID);

        
    }
}
