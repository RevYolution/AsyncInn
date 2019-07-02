using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenityManager
    {
        /// <summary>
        /// Add an amenity to a room
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        Task AddAmenityAsync(Amenities amenities);


        /// <summary>
        /// Deletes an amenity from a room 
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        Task DeleteAmenityAsync(int id);

        /// <summary>
        /// Provides all the amenities
        /// </summary>
        /// <returns></returns>
        Task<List<Amenities>> GetAmenitiesAsync();

        /// <summary>
        /// Gets a single amenity 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Amenities> GetAmenityAsync(int? id);
    }
}
