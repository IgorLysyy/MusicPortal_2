using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Models
{
    public class Sound
    {
        public Sound()
        {
            genres = new List<Genre>();
        }
        [Key]
        public int Id { get; set; }
        public string SoundName { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string Lyrics { get; set; }
        public string Image { get; set; }
        public ICollection<Genre> genres { get; set; }
    }
}