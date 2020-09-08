using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelWebApi.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string BranchImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase BranchImageFile { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}