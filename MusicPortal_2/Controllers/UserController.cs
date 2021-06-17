using MusicPortal_2.Filters;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using MusicPortal_2.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MusicPortal_2.Controllers
{
    public class UserController : Controller
    {
        IRepository<UserRole> IRole;
        IRepository<UserAccount> IUser;

        public UserController()
        {

        }
        public UserController(IRepository<UserRole> role, IRepository<UserAccount> user)
        {
            IUser = user;
            IRole = role;
        }
        public UserController(IRepository<UserAccount> user)
        {
            IUser = user;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "NickName,Email,Password")] UserAccount user)
        {
            if(ModelState.IsValid)
            {
                //Создание соли для пароля
                GenerateSalt generateSalt = new GenerateSalt();
                string salt = generateSalt.CreateSalt(16);
                //Хеширование пароля
                Hasher hasher = new Hasher();
                user.Password = hasher.HashPassword(salt,user.Password);

                user.Salt = salt;
                var userRole = IRole.GetObjectList().Where(a => a.RoleName == "User");
                user.Role = userRole.FirstOrDefault();
                user.ImageName = "Default.png";
                IUser.Attach(user);
                IUser.CreateObject(user);
                try
                {
                    IUser.Save();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Your nickname must be unique");
                    return View("Registration", user);
                }
                return RedirectToAction("Index","Home");
            }
            return View("Registration", user);
        }
        [HttpGet]
        [SessionFilter]
        public ActionResult Registration()
        {
            return View("Registration");
        }
        [HttpGet]
        [SessionFilter]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpGet]
        public new ActionResult Profile()
        {
            UserAccount user = new UserAccount();
            user = IUser.GetObject((int)Session["UserId"]);
            return View("Profile",user);
        }
        [HttpPost]
        public new ActionResult Profile(HttpPostedFileBase upload)
        {

            string fileName = System.IO.Path.GetFileName(upload.FileName);
            // сохраняем файл в папку Files в проекте
            upload.SaveAs(Server.MapPath("~/Image/UserImage/" + fileName));



            UserAccount user = new UserAccount();
            user = IUser.GetObject((int)Session["UserId"]);

            if(user.ImageName!= "Default.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Image/UserImage/"+user.ImageName));
            }

            user.ImageName = upload.FileName;
            IUser.Attach(user);
            IUser.UpdateObject(user);
            IUser.Save();




            return View("Profile", user);
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {

                var users = IUser.GetObjectList();
                if (users.Count()== 0)
                {
                    ModelState.AddModelError("", "Wrond login or password!");
                    return View("Login", user);
                }
                if (users.Where(a => a.Nickname == user.Nickname).Count() == 0)
                {

                    ModelState.AddModelError("", "Wrond login or password!");
                return View("Login", user);
                }
                  var userCheck = users.Where(a => a.Nickname == user.Nickname).FirstOrDefault();
                  string salt = userCheck.Salt;

                Hasher hasher = new Hasher();
                string hashPassword = hasher.HashPassword(salt, user.Password);
                if(userCheck.Password + userCheck.Salt!= hashPassword + userCheck.Salt)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                return View("Login", user);
                }

            Session.Add("UserNickname", userCheck.Nickname);
            Session.Add("UserId", userCheck.id);

            return RedirectToAction("Index", "Home");

        }

        [SessionFilter]
        public ActionResult Logout()
        {
            return RedirectToAction("Index","Home");
        }
    }
}