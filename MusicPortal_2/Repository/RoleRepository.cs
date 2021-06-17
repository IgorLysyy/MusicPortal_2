using MusicPortal_2.DataBaseContext;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Repository
{
    public class RoleRepository : IRepository<UserRole>
    {
        private MainContext sc;
        public RoleRepository()
        {
            sc = new MainContext();
        }
        public void Attach(UserRole obj)
        {
            sc.userRoles.Attach(obj);
        }

        public void CreateObject(UserRole item)
        {
            sc.userRoles.Add(item);
        }

        public void DeleteObject(int id)
        {
            UserRole role = sc.userRoles.Find(id);
            if(role != null)
            {
                sc.userRoles.Remove(role);
            }
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    sc.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<UserRole> GetObjectList()
        {
            return sc.userRoles.ToList();
        }

        public UserRole GetObject(int id)
        {
            return sc.userRoles.Find(id);
        }

        public void Save()
        {
            sc.SaveChanges();
        }

        public void UpdateObject(UserRole item)
        {
            sc.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

       
    }
}