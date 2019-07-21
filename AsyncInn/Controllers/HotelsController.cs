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
    public class HotelsController : Controller
    {
        /// <summary>
        /// Context for Hotel
        /// </summary>
        private readonly IHotelManager _context;

        /// <summary>
        /// Initializes new instance of the Hotel controller
        /// </summary>
        /// <param name="context"></param>
        public HotelsController(IHotelManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Directs to Hotel Home Page and displays all Hotels in the Database
        /// </summary>
        /// <returns>Hotel Home Page</returns>
        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetHotels());
        }

        /// <summary>
        /// Shows the details of an Hotel based off its ID
        /// </summary>
        /// <param name="id">ID of the Hotel</param>
        /// <returns>Detail Page of Hotel</returns>
        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// Allows for the creation of a new Hotel
        /// </summary>
        /// <returns>Directs to the Create View Page</returns>
        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new Hotel in the database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Hotel Home Page with the new Hotel</returns>
        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StreetAddress,City,State,PhoneNumber")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.AddHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        /// <summary>
        /// Allows for Updating of a Hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit View Page for a Hotel</returns>
        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        /// <summary>
        /// Updates the Hotel in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns>Hotel Home Page with the Updated Hotel</returns>
        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StreetAddress,City,State,PhoneNumber")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _context.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await HotelExists(hotel.ID))
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
            return View(hotel);
        }

        /// <summary>
        /// Allows for the Removal of a Hotel 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete View Page of a Hotel</returns>
        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// Removes a Hotel in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hotel Home Page without the given Hotel</returns>
        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if a Hotel exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> HotelExists(int id)
        {
            var hotel = await _context.GetHotel(id);
            if(hotel != null)
            {
                return true;
            }

            return false;
        }
    }
}
