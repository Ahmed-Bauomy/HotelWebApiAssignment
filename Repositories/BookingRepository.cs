using HotelWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApi.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly ApplicationDbContext DbContext;
        public BookingRepository(ApplicationDbContext _db)
        {
            DbContext = _db;
        }
        public void AddItem(Booking item)
        {
            DbContext.Bookings.Add(item);
            DbContext.SaveChanges();
        }

        public void DeleteItem(string id)
        {
            var room = GetItem(id);
            DbContext.Bookings.Remove(room);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void EditItem(Booking item)
        {
            DbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public List<Booking> GetAllItems()
        {
            return DbContext.Bookings.ToList();
        }

        public Booking GetItem(string id)
        {
            return DbContext.Bookings.SingleOrDefault(r => r.BookingId == id);
        }
    }
}