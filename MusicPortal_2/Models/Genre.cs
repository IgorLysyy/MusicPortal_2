using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Models
{
    public class Genre
    {
        public Genre()
        {
            sounds = new List<Sound>();
        }
        [Key]
        public int id { get; set; }
        public string genreName { get; set; }
        public ICollection<Sound> sounds { get; set; }
    }
}