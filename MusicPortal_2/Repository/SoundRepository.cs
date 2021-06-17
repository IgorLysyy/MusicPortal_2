using MusicPortal_2.DataBaseContext;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Repository
{
    public class SoundRepository : IRepository<Sound>
    {
        private MainContext mc;
        public SoundRepository()
        {
            mc = new MainContext();
        }
        public void Attach(Sound obj)
        {
            mc.sounds.Attach(obj);
        }

        public void CreateObject(Sound item)
        {
            mc.sounds.Add(item);
        }

        public void DeleteObject(int id)
        {
            Sound sound = mc.sounds.Find(id);
            if(sound!=null)
            {
                mc.sounds.Remove(sound);
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

        public Sound GetObject(int id)
        {
          return  mc.sounds.Find(id);
        }

        public IEnumerable<Sound> GetObjectList()
        {
            return mc.sounds.ToList();
        }

        public void Save()
        {
            mc.SaveChanges();
        }

        public void UpdateObject(Sound item)
        {
            mc.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}