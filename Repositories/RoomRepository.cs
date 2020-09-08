using HotelWebApi.HelperClasses;
using HotelWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelWebApi.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly ApplicationDbContext DbContext;
        public RoomRepository(ApplicationDbContext _db)
        {
            DbContext = _db;
        }
        public void AddItem(Room item)
        {
            item.RoomImagePath = HelperMethods.SaveFile(item.RoomImageFile,"~/Images/Rooms");
            DbContext.Rooms.Add(item);
            DbContext.SaveChanges();
        }
 
        public void DeleteItem(string id)
        {
            var room = GetItem(id);
            DbContext.Rooms.Remove(room);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void EditItem(Room item)
        {
            DbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public List<Room> GetAllItems()
        {
            return DbContext.Rooms.ToList();
        }

        public Room GetItem(string id)
        {
            int Id = int.Parse(id);
            return DbContext.Rooms.SingleOrDefault(r=>r.RoomId == Id);
        }
    }
}