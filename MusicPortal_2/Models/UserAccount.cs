using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicPortal_2.Models
{
    public class UserAccount
    {
        [Key]
     public   int id { get; set; }

        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 25 characters")]
        public string Nickname { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string ImageName { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 characters")]
        public string Password { get; set; }
        [NotMapped]
        public string RepeatPassword { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
    }
}