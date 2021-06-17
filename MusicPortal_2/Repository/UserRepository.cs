using MusicPortal_2.DataBaseContext;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Repository
{
    public class UserRepository : IRepository<UserAccount>
    {
        private MainContext mc;
        public UserRepository()
        {
            mc = new MainContext();
        }
        public void Attach(UserAccount obj)
        {
            mc.userAccounts.Attach(obj);
        }

        public void CreateObject(UserAccount item)
        {
            mc.userAccounts.Add(item);
        }

        public void DeleteObject(int id)
        {
            UserAccount user = mc.userAccounts.Find(id);
            if(user!=null)
            {
                mc.userAccounts.Remove(user);
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

        public UserAccount GetObject(int id)
        {
            return mc.userAccounts.Find(id);
        }

        public IEnumerable<UserAccount> GetObjectList()
        {
            return mc.userAccounts.ToList();
        }

        public void Save()
        {
            mc.SaveChanges();
        }

        public void UpdateObject(UserAccount item)
        {
            mc.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}