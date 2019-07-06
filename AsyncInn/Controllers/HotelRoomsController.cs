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
    public class HotelRoomsController : Controller
    {
        //private readonly AsyncInnDbContext _context;

        /// <summary>
        /// The context
        /// </summary>
        private readonly IHotelManager _hotels;

        /// <summary>
        /// The rooms
        /// </summary>
        private readonly IRoomManager _rooms;

        //public HotelRoomsController(AsyncInnDbContext context)
        //{
        //    _context = context;
        //}

        public HotelRoomsController(IHotelManager hotels, IRoomManager rooms)
        {
            _hotels = hotels;
            _rooms = rooms;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            return View(await _hotels.GetHotelRooms());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? hotelID, int? roomNumber)
        {
            if (hotelID == null || roomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _hotels.GetHotelRoom(hotelID.Value, roomNumber.Value);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);

        }

        // GET: HotelRooms/Create
        public async  Task<IActionResult> Create()
        {
            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "Name");
            ViewData["RoomID"] = new SelectList(await _rooms.GetRoomsAsync(), "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            bool isValid = ModelState.IsValid;

            if (isValid && await _hotels.HotelRoomIsPresent(hotelRoom.HotelID, hotelRoom.RoomNumber))
            {
                ModelState.AddModelError("RoomNumber", "Room number already exists in the hotel.");
                isValid = false;
            }

            if (isValid)
            {
                await _hotels.AddHotelRoom(hotelRoom); ;
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(await _rooms.GetRoomsAsync(), "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? hotelID, int? roomNumber)
        {

            if (hotelID == null || roomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _hotels.GetHotelRoom(hotelID.Value, roomNumber.Value);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(await _rooms.GetRoomsAsync(), "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            bool isValid = ModelState.IsValid;


            if (isValid)
            {

                try
                {
                    await _hotels.UpdateHotelRoom(hotelRoom);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _hotels.HotelRoomIsPresent(hotelRoom.RoomID, hotelRoom.RoomNumber))
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
            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(await _rooms.GetRoomsAsync(), "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? hotelID, int? roomNumber)
        {
            if (hotelID == null || roomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _hotels.GetHotelRoom(hotelID.Value, roomNumber.Value);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hotelID, int roomNumber)
        {
            await _hotels.DeleteHotelRoom(hotelID, roomNumber);
            return RedirectToAction(nameof(Index));
        }

    }
}
