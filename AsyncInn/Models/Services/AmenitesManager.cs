using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitesManager : IAmenityManager
    {
        private AsyncInnDbContext _context;

        public AmenitesManager(AsyncInnDbContext context)
        {
            _context = context;
        }
        public Task AddAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Amenities>> GetAmenities()
        {
            throw new NotImplementedException();
        }

        public Task<Amenities> GetAmenities(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }
    }
}
