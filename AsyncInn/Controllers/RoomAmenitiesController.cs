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
    public class RoomAmenitiesController : Controller
    {
        private readonly IRoomManager _rooms;
        private readonly IAmenityManager _amenities;
        public RoomAmenitiesController(IRoomManager rooms, IAmenityManager amenities)
        {
            _rooms = rooms;
            _amenities = amenities;
        }

        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            return View(await _rooms.GetRoomAmenitiesAsync());
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int? amenityID, int? roomID)
        {
            if (roomID == null || amenityID == null)
            {
                return NotFound();
            }

            var roomAmenity = await _rooms.GetRoomAmenitiesAsync(amenityID.Value, roomID.Value);

            if (roomAmenity == null)
            {
                return NotFound();
            }

            return View(roomAmenity);
        }

        // GET: RoomAmenities/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AmenityID"] = new SelectList(await _amenities.GetAmenitiesAsync(), "ID", "Name");
            ViewData["RoomID"] = new SelectList(await _rooms.GetRoomsAsync(), "ID", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,AmenitiesID")] RoomAmenities roomAmenities)
        {
            bool isValid = ModelState.IsValid;

            if (isValid && await _rooms.RoomAmenityPresentAsync(roomAmenities.RoomID, roomAmenities.AmenitiesID))
            {
                ModelState.AddModelError("", "Amenity is already part of the room.");
                isValid = false;
            }

            if (ModelState.IsValid)
            {
                await _rooms.AddRoomAmenityAsync(roomAmenities);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityID"] = new SelectList(await _amenities.GetAmenitiesAsync(), "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(await _rooms.GetRoomsAsync(), "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }



        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? amenitiesID, int? roomID)
        {
            if (amenitiesID == null || roomID == null)
            {
                return NotFound();
            }

            var roomAmenities = await _rooms.GetRoomAmenitiesAsync(amenitiesID.Value, roomID.Value);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int amenitiesID, int roomID)
        {
            await _rooms.DeleteRoomAmenityAsync(amenitiesID, roomID);
            return RedirectToAction(nameof(Index));
        }

    }
}
