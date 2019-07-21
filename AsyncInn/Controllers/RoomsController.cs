using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class RoomsController : Controller
    {
        /// <summary>
        /// Context for Rooms
        /// </summary>
        private readonly IRoomManager _context;

        /// <summary>
        /// Initializes new instance of the Rooms controller
        /// </summary>
        /// <param name="context"></param>
        public RoomsController(IRoomManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Directs to Rooms Home Page and displays all Rooms in the Database
        /// </summary>
        /// <returns>Rooms Home Page</returns>
        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetRoomsAsync());
        }

        /// <summary>
        /// Shows the details of a Room based off its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Detail Page of Room</returns>
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var room = await _context.GetRoomAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Allows for the creation of a new Room
        /// </summary>
        /// <returns>Directs to the Create View Page</returns>
        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new Room in the database
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Room Home Page with the new Room</returns>
        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _context.AddRoomAsync(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        /// <summary>
        /// Allows for Updating of a Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit View Page for a Room</returns>
        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var room = await _context.GetRoomAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        /// <summary>
        /// Updates the Room in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns>Hotel Room Page with the Updated Room</returns>
        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateRoomAsync(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            return View(room);
        }

        /// <summary>
        /// Allows for the Removal of a Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete View Page of a Room</returns>
        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var room = await _context.GetRoomAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Removes a Room in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Room Home Page without the given Room</returns>
        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteRoomAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks for a given Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RoomExists(int id)
        {
            return _context.GetRoomAsync(id) != null;
        }
    }
}
