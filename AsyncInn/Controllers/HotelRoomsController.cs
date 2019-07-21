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
    public class HotelRoomsController : Controller
    {
        /// <summary>
        /// Context for Hotel Rooms
        /// </summary>
        private readonly AsyncInnDbContext _context;

        /// <summary>
        /// Initializes new instance of the HotelRooms controller
        /// </summary>
        /// <param name="context"></param>
        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Directs to Hotel Home Rooms Page and displays all Hotel Rooms in the Database
        /// </summary>
        /// <returns>Hotel Rooms Home Page</returns>
        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Gets Hotel Room Details based off the Room ID and Hotel ID
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns>Detail View Page of a Hotel Room</returns>
        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int roomID, int hotelID)
        {
            if (roomID == 0 || hotelID == 0)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Allow for the Creation of a new Hotel Room
        /// </summary>
        /// <returns>Returns Hotel Room Create Page</returns>
        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        /// <summary>
        /// Adds the Created Hotel Room to database
        /// </summary>
        /// <param name="hotelRoom"></param>
        /// <returns>Hotel Room Home Page with newly added Hotel Room</returns>
        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Allows for the Editing of a Hotel Room
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns>Edit Page for Hotel Room</returns>
        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int roomID, int hotelID)
        {
            if (roomID == 0 || hotelID == 0)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                            .Include(h => h.Hotel)
                            .Include(h => h.Room)
                            .FirstOrDefaultAsync(m => m.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Updates the Hotel Room in the database
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <param name="hotelRoom"></param>
        /// <returns>Hotel Room Home Page with updated Hotel Room</returns>
        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int roomID, int hotelID, [Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Allows for the Removal of a Hotel Room
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns>Delete Page for Hotel Room</returns>
        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int roomID, int hotelID)
        {
            if (roomID == 0 || hotelID == 0)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Confirms the Hotel Room to be Removed
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns>Hotel Room Home Page without the Hotel Room</returns>
        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int roomID, int hotelID)
        {

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelID);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check to see if the Hotel Room Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}