using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWebApi.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAllItems();
        T GetItem(string id);
        void AddItem(T item);
        void EditItem(T item);
        void DeleteItem(string id);
        void Dispose();
    }
}
