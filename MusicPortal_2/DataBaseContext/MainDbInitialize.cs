using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MusicPortal_2.Models;

namespace MusicPortal_2.DataBaseContext
{
    public class MainDbInitialize : CreateDatabaseIfNotExists<MainContext>
    {
        protected override void Seed(MainContext db)
        {
           var Role_User = new UserRole {RoleName = "User" };
            var Role_Administrator = new UserRole { RoleName = "Administrator" };

            db.userRoles.Add(Role_User);
            db.userRoles.Add(Role_Administrator);

            db.genres.Add(new Genre { genreName = "Другое" });
            db.genres.Add(new Genre { genreName = "Поп-музыка" });
            db.genres.Add(new Genre { genreName = "Рок" });
            db.genres.Add(new Genre { genreName = "Металл" });
            db.genres.Add(new Genre { genreName = "Хип-хоп" });
            db.genres.Add(new Genre { genreName = "Рэп" });
            db.genres.Add(new Genre { genreName = "Джаз" });
            db.genres.Add(new Genre { genreName = "Инструментальная музыка" });
            db.genres.Add(new Genre { genreName = "Электро" });
            db.genres.Add(new Genre { genreName = "Музыка в стиле Транс" });

            base.Seed(db);
        }
    }
}