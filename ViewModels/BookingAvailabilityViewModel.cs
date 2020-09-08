using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApi.ViewModels
{
    public class BookingAvailabilityViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BranchId { get; set; }
    }
}