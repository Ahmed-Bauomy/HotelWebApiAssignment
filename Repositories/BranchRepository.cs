using HotelWebApi.HelperClasses;
using HotelWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApi.Repositories
{
    public class BranchRepository : IRepository<Branch>
    {
        private readonly ApplicationDbContext DbContext;
        public BranchRepository(ApplicationDbContext _db)
        {
            DbContext = _db;
        }
        public void AddItem(Branch item)
        {
            item.BranchImagePath = HelperMethods.SaveFile(item.BranchImageFile, "~/Images/Branches");
            DbContext.Branchs.Add(item);
            DbContext.SaveChanges();
        }

        public void DeleteItem(string id)
        {
            var branch = GetItem(id);
            DbContext.Branchs.Remove(branch);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void EditItem(Branch item)
        {
            DbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public List<Branch> GetAllItems()
        {
            return DbContext.Branchs.ToList();
        }
        public Branch GetItem(string id)
        {
            int Id = int.Parse(id);
            return DbContext.Branchs.SingleOrDefault(B => B.BranchId == Id);
        }
    }
}