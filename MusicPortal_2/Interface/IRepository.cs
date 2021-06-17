using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal_2.Interface
{
   public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetObjectList();
        T GetObject(int id);
        void CreateObject(T item);
        void UpdateObject(T item);
        void DeleteObject(int id);
        void Attach(T obj);
        void Save();
    }

}
