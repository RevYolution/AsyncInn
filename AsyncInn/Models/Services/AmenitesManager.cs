using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddAmenityAsync(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenityAsync(int id)
        {
            Amenities Amenity = await GetAmenityAsync(id);
            _context.Amenities.Remove(Amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenities>> GetAmenitiesAsync()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenityAsync(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

    }
}
