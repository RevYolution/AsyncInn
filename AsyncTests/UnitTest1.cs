using AsyncInn.Models;
using System;
using Xunit;

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
        public void CanGetNameOfAmenity()
        {
            Amenities testAmenity = new Amenities();
            testAmenity.Name = "Test Amenity";
            Amenities.Equals("Test Amenity", testAmenity.Name);
        }
    }
}
