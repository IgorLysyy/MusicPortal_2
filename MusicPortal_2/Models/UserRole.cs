using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Models
{
    public class UserRole
    {
        [Key]
        public int id { get;set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Role is required")]
        public string RoleName { get; set; }
    }
}