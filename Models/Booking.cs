using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelWebApi.Models
{
    public class Booking
    {
        public string BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public int NumberOfPersons { get; set; }
        public bool BookingApproved { get; set; }
        public virtual Room Room { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}