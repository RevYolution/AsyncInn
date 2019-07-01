using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenityManager
    {
        /// <summary>
        /// Add an amenity to a room
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        Task AddAmenity(Amenities amenities);

        /// <summary>
        /// Update an amenity for a room
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        Task UpdateAmenity(Amenities amenities);

        /// <summary>
        /// Deletes an amenity from a room 
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        Task DeleteAmenity(Amenities amenities);

        /// <summary>
        /// Provides all the amenities
        /// </summary>
        /// <returns></returns>
        Task<List<Amenities>> GetAmenities();

        /// <summary>
        /// Gets a single amenity 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Amenities> GetAmenities(int? id);
    }
}
