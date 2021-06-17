using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicPortal_2.Controllers
{
    public class AddSoundController : Controller
    {
        IRepository<Genre> IGenre;
        IRepository<Sound> ISound;

        public AddSoundController()
        {

        }
        public AddSoundController(IRepository<Genre> genre, IRepository<Sound> sound)
        {
            IGenre = genre;
            ISound = sound;
        }
        // GET: AddSound
        [HttpGet]
        public ActionResult Index()
        {
            SelectList genres = new SelectList(IGenre.GetObjectList(), "id", "genreName");
            ViewBag.Genres = genres;
            return View();
        }
        [HttpPost]
        public ActionResult GetSoundInformation(int[] idForSound, HttpPostedFileBase fileUpload)
        {
            List<Genre> genreList = new List<Genre>();
            for (int i = 0; i < idForSound.Length; i++)
            {
                genreList.Add(IGenre.GetObject(idForSound[i]));
            }

            string tempfolder = Server.MapPath("~/Sound");
            var fullpath = Request.MapPath("~/Sound");
           
            if (fileUpload.FileName != null)
            {
                fileUpload.SaveAs(Path.Combine(tempfolder, fileUpload.FileName));
            }

            var FileInfo = TagLib.File.Create(fullpath + "\\" + fileUpload.FileName);

            Sound sound = new Sound();
            sound.genres = genreList;
            if (FileInfo.Tag.Album != null)
                sound.Album = FileInfo.Tag.Album;
            if(FileInfo.Tag.Artists.First()!=null)
                sound.Author = FileInfo.Tag.Artists.First();

            sound.Lyrics = FileInfo.Tag.Lyrics;
            sound.SoundName = fileUpload.FileName;
            var ImagePath = Request.MapPath("~/Image/SoundImage");
            try
            {
                var name = new string(fileUpload.FileName.ToCharArray().Reverse().ToArray());
                name = new string(name.Split('.')[1].ToCharArray().Reverse().ToArray());
                var image = FileInfo.Tag.Pictures.First();
                System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(image.Data.Data));
                var fullImagePath = ImagePath + "\\" + name + ".png";
                x.Save(fullImagePath);
                sound.Image =name + ".png";
            }
            catch (System.InvalidOperationException)
            {

                sound.Image = "NoPhoto.jpg";
            }
            ISound.Attach(sound);
            ISound.CreateObject(sound);
            ISound.Save();

            return RedirectToAction("Profile","User");
        }
    }
}