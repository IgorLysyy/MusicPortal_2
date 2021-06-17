using MusicPortal_2.DataBaseContext;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        private MainContext mc;
        public GenreRepository()
        {
            mc = new MainContext();
        }
        public void Attach(Genre obj)
        {
            mc.genres.Attach(obj);
        }

        public void CreateObject(Genre item)
        {
            mc.genres.Add(item);
        }

        public void DeleteObject(int id)
        {
            Genre genre = mc.genres.Find(id);
            if(genre!=null)
            {
                mc.genres.Remove(genre);
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    mc.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Genre GetObject(int id)
        {
          return  mc.genres.Find(id);
        }

        public IEnumerable<Genre> GetObjectList()
        {
            return mc.genres.ToList();
        }

        public void Save()
        {
            mc.SaveChanges();
        }

        public void UpdateObject(Genre item)
        {
            mc.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}