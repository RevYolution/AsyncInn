using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom
    }

    public class Room
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

}
