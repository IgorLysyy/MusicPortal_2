using Autofac;
using Autofac.Integration.Mvc;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using MusicPortal_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicPortal_2.Util
{
    public  class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<RoleRepository>().As<IRepository<UserRole>>();
            builder.RegisterType<UserRepository>().As<IRepository<UserAccount>>();
            builder.RegisterType<GenreRepository>().As<IRepository<Genre>>();
            builder.RegisterType<SoundRepository>().As<IRepository<Sound>>();
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}