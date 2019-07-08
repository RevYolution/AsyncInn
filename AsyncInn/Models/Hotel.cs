using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;

namespace AsyncInn.Models
{
    public class Hotel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<HotelRoom> Rooms { get; set; }

    }
}
