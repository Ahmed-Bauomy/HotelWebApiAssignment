
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelWebApi.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Description { get; set; }
        public decimal PriceForNight { get; set; }
        public float Rate { get; set; }
        public RoomType RoomType { get; set; }
        public int NumberOfPersons { get; set; }

        [NotMapped]
        public HttpPostedFileBase RoomImageFile { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public string RoomImagePath { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Branch Branch { get; set; }
    }
    public enum RoomType
    {
        Single,
        Double,
        Suite
    }
}