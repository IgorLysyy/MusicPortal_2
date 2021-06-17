using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicPortal_2.Models;

namespace MusicPortal_2.DataBaseContext
{
    public class MainContext : DbContext
    {
        public MainContext()
           : base("MusicPortalData")
        {
        }
        public DbSet<UserAccount> userAccounts { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Sound> sounds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasIndex(u => u.Nickname).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}