using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {
        }
           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(
                hr => new { hr.HotelID, hr.RoomNumber }
                );
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ra => new { ra.RoomID, ra.AmenitiesID }
                );

            //Seeds data into the database.
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Loc of Ness Inn",
                    StreetAddress = "204 Just Around the River Bend Ave",
                    City = "Tacoma",
                    State = "WA",
                    PhoneNumber = 8675309
                },

                new Hotel
                {
                    ID = 2,
                    Name = "Samsquach Inn",
                    StreetAddress = "7156 Yonder Forest Ln",
                    City = "Bellingham",
                    State = "WA",
                    PhoneNumber = 555849
                },

                new Hotel
                {
                    ID = 3,
                    Name = "The House that Jack Built Inn",
                    StreetAddress = "8945 Breadcrumb St",
                    City = "Redmond",
                    State = "WA",
                    PhoneNumber = 555555
                },

                new Hotel
                {
                    ID = 4,
                    Name = "Holy Diver Inn",
                    StreetAddress = "2149 Above All Ave",
                    City = "Seattle",
                    State = "WA",
                    PhoneNumber = 784512
                },
                
                new Hotel
                {
                    ID = 5,
                    Name = "Thunder from Down Under",
                    StreetAddress = "52 Wallibee Way",
                    City = "Sydney",
                    State = "OR",
                    PhoneNumber = 951623
                });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Oasis",
                    Layout= Layout.OneBedroom
                },

                new Room
                {
                    ID = 2,
                    Name = "Wonderwall",
                    Layout = Layout.TwoBedroom
                },

                new Room
                {
                    ID = 3,
                    Name = "Anberlin",
                    Layout = Layout.studio
                },

                new Room
                {
                    ID = 4,
                    Name = "Paperthin Hymn",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Paramore",
                    Layout = Layout.studio
                },
                new Room
                {
                    ID = 6,
                    Name = "Riot",
                    Layout = Layout.TwoBedroom
                });

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Microwave"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Fridge"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "A/C"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Hot Tub"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Deck"
                },
                new Amenities
                {
                    ID = 6,
                    Name = "DJ"
                },
                new Amenities
                {
                    ID = 7,
                    Name = "Complementary Bar"
                });
        }
        
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }

    }
}
