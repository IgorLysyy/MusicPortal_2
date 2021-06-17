using MusicPortal_2.DataBaseContext;
using MusicPortal_2.Filters;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicPortal_2.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Genre> IGenre;
        IRepository<Sound> ISound;
      

        public HomeController()
        {

        }
        public HomeController(IRepository<Genre> genre, IRepository<Sound> sound)
        {
            IGenre = genre;
            ISound = sound;
        }
        public HomeController(IRepository<Sound> sound)
        {
         
            ISound = sound;
        }
        [HttpGet]

        public ActionResult Index()
        {
            List<Sound> sounds = new List<Sound>();
            sounds = ISound.GetObjectList().ToList();          
            return View(sounds);
        }
        public ActionResult ShowSound()
        {
            Sound sound = new Sound();
            sound = ISound.GetObject(1);

            return View(sound);
        }


    }
}