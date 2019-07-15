using AsyncInn.Models;
using System;
using Xunit;
using AsyncInn;
using AsyncInn.Models.Services;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.Interfaces;

namespace AsyncTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetNameOfHotel()
        {
            Hotel testHotel = new Hotel();
            testHotel.Name = "Over There and Everywhere";
            Hotel.Equals("Over There and Everywhere", testHotel.Name);
        }

        [Fact]
        public void CanGetHotelID()
        {
            Hotel testHotel = new Hotel();
            testHotel.ID = 3;
            Hotel.Equals(3, testHotel.ID);
        }

        [Fact]
        public void CanGetHotelAddress()
        {
            Hotel testHotel = new Hotel();
            testHotel.StreetAddress = "451 Test Ave";
            Hotel.Equals("451 Test Ave", testHotel.StreetAddress);
        }

        [Fact]
        public void CanGetHotelCity()
        {
            Hotel testHotel = new Hotel();
            testHotel.City = "Test City";
            Hotel.Equals("Test City", testHotel.City);
        }

        [Fact]
        public void CanGetHotelState()
        {
            Hotel testHotel = new Hotel();
            testHotel.State = "WA";
            Hotel.Equals("WA", testHotel.State);
        }

        [Fact]
        public void CanGetHotelPhonenumber()
        {
            Hotel testHotel = new Hotel();
            testHotel.PhoneNumber = 456789123;
            Hotel.Equals(456789123, testHotel.PhoneNumber);
        }

        [Fact]
        public void CanSetHotelID()
        {
            Hotel testHotel = new Hotel();
            testHotel.ID = 1;
            testHotel.ID = 2;
            Hotel.Equals(2, testHotel.ID);
        }

        [Fact]
        public void CanSetHotelName()
        {
            Hotel testHotel = new Hotel();
            testHotel.Name = "Test1";
            testHotel.Name = "Test2";
            Hotel.Equals("Test2", testHotel.Name);
        }

        [Fact]
        public void CanSetHotelAddress()
        {
            Hotel testHotel = new Hotel();
            testHotel.StreetAddress = "Test Address 1";
            testHotel.StreetAddress = "Test Address 2";
            Hotel.Equals("Test Address 2", testHotel.StreetAddress);
        }

        [Fact]
        public void CanSetHotelCity()
        {
            Hotel testHotel = new Hotel();
            testHotel.City = "City 1";
            testHotel.City = "City 2";
            Hotel.Equals("City 2", testHotel.City);
        }

        [Fact]
        public void CanSetHotelState()
        {
            Hotel testHotel = new Hotel();
            testHotel.State = "State 1";
            testHotel.State = "State 2";
            Hotel.Equals("State 2", testHotel.State);
        }

        [Fact]
        public void CanSetHotelPhonenumber()
        {
            Hotel testHotel = new Hotel();
            testHotel.PhoneNumber = 456;
            testHotel.PhoneNumber = 123;
            Hotel.Equals(123, testHotel.PhoneNumber);
        }


        [Fact]
        public void CanGetNameOfRoom()
        {
            Room testRoom = new Room();
            testRoom.Name = "Test Room";
            Room.Equals("Test Room", testRoom.Name);
        }

        [Fact]
        public void CanGetRoomID()
        {
            Room testRoom = new Room();
            testRoom.ID = 5;
            Room.Equals(5, testRoom.ID);
        }

        [Fact]
        public void CanGetRoomLayout()
        {
            Room testRoom = new Room();
            testRoom.Layout = Layout.OneBedroom;
            Room.Equals(Layout.OneBedroom, testRoom.Layout);
        }

        [Fact]
        public void CanSetRoomID()
        {
            Room testRoom = new Room();
            testRoom.ID = 1;
            testRoom.ID = 2;
            Room.Equals(2, testRoom.ID);
        }

        [Fact]
        public void CanSetRoomName()
        {
            Room testRoom = new Room();
            testRoom.Name = "Test Room 1";
            testRoom.Name = "Test Room 2";
            Room.Equals("Test Room 2", testRoom.Name);
        }

        [Fact]
        public void CanSetRoomLayout()
        {
            Room testRoom = new Room();
            testRoom.Layout = Layout.OneBedroom;
            testRoom.Layout = Layout.Studio;
            Room.Equals(Layout.Studio, testRoom.Layout);
        }


        [Fact]
        public void CanGetNameOfAmenity()
        {
            Amenities testAmenity = new Amenities();
            testAmenity.Name = "Test Amenity";
            Amenities.Equals("Test Amenity", testAmenity.Name);
        }

        [Fact]
        public void CanGetIDOfAmenity()
        {
            Amenities testAmenity = new Amenities();
            testAmenity.ID = 1;
            Amenities.Equals(1, testAmenity.ID);
        }

        [Fact]
        public void CanGetAmenityID()
        {
            Amenities testAmenity = new Amenities();
            testAmenity.ID = 1;
            testAmenity.ID = 2;
            Amenities.Equals(2, testAmenity.ID);
        }

        [Fact]
        public void CanSetAmenityName()
        {
            Amenities testAmenity = new Amenities();
            testAmenity.Name = "Test Amenity 1";
            testAmenity.Name = "Test Amenity 2";
            Amenities.Equals("Test Amenity 2", testAmenity.Name);
        }

        [Fact]
        public void CanGetRoomAmenityAmentiesID()
        {
            RoomAmenities testRoomAmenity = new RoomAmenities();
            testRoomAmenity.AmenitiesID = 1;
            RoomAmenities.Equals(1, testRoomAmenity.AmenitiesID);
        }

        [Fact]
        public void CanGetRoomAmenityRoomID()
        {
            RoomAmenities testRoomAmenity = new RoomAmenities();
            testRoomAmenity.RoomID = 1;
            RoomAmenities.Equals(1, testRoomAmenity.RoomID);
        }

        [Fact]
        public void CanSetRoomAmenityAmenitiesID()
        {
            RoomAmenities testRoomAmenity = new RoomAmenities();
            testRoomAmenity.AmenitiesID = 1;
            testRoomAmenity.AmenitiesID = 2;
            RoomAmenities.Equals(2, testRoomAmenity.AmenitiesID);
        }

        [Fact]
        public void CanSetRoomAmenityRoomID()
        {
            RoomAmenities testRoomAmenity = new RoomAmenities();
            testRoomAmenity.RoomID = 1;
            testRoomAmenity.RoomID = 2;
            RoomAmenities.Equals(2, testRoomAmenity.RoomID);
        }

        //[Fact]
        //public async Task CanCreateHotelAsync()
        //{
        //    DbContextOptions<AsyncInnDbContext> options = new
        //        DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase
        //        ("CreateHotel").Options;

        //    using (AsyncInnDbContext context = new AsyncInnDbContext
        //        (options))
        //    {
        //        Hotel hotelServices = new Hotel(context);

        //        //Arrange
        //        Hotel hotel = new Hotel(context);
        //        hotel.ID = 1;
        //        hotel.Name = "TEST";
        //        hotel.StreetAddress = "Test address";
        //        hotel.City = "Seattle";
        //        hotel.State = "WA";
        //        hotel.PhoneNumber = 456123789;

        //        //Act
        //        await hotelServices.Create(hotel);

        //        var result = context.Hotels.FirstOrDefault(h => h.Rooms == h.Rooms);

        //        Assert.NotNull(context.Hotels.Find(hotel.ID));
        //    }
        //}
    }
}
