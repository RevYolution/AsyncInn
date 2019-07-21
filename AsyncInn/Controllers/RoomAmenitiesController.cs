using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        /// <summary>
        /// Context for Room Amenities
        /// </summary>
        private readonly AsyncInnDbContext _context;

        /// <summary>
        /// Initializes new instance of the Room Amenities
        /// </summary>
        /// <param name="context"></param>
        public RoomAmenitiesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Directs to the Room Amenities Home Page and dispalys all Room Amenities
        /// </summary>
        /// <returns>Room Amenities Home Page</returns>
        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenities).Include(r => r.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Shows the details of a Room Amenity based off its ID
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="amenitiesID"></param>
        /// <returns>Detail Page of Room Amenity</returns>
        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int roomID, int amenitiesID)
        {
            if (roomID == 0|| amenitiesID == 0) 
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.AmenitiesID == amenitiesID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        /// <summary>
        /// Allows for the creation of a new Room Amenity
        /// </summary>
        /// <returns>Directs to the Create View Page</returns>
        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        /// <summary>
        /// Creates a new Room Amenity in the database
        /// </summary>
        /// <param name="roomAmenities"></param>
        /// <returns>Room Amenity Home Page with the new Room Amenity</returns>
        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,AmenitiesID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }


        /// <summary>
        /// Allows for the Removal of a Room Amenity
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="amenitiesID"></param>
        /// <returns>Delete View Page of a Room Amenity</returns>
        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int roomID, int amenitiesID)
        {
            if (roomID == 0 || amenitiesID == 0)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == roomID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        /// <summary>
        /// Removes a Room Amenity in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Room Amenity Home Page without the given Room Amenity</returns>
        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.RoomID == id);
        }
    }
}