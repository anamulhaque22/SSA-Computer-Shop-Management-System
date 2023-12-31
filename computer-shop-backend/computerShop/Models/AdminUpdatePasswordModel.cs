using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace computerShop.Models
{
    public class AdminUpdatePasswordModel
    {
        [Required]
        public string currPassword { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z].*[A-Za-z])(?=.*\\d)(?=.*[^A-Za-z\\d\\s].*[^A-Za-z\\d\\s]).{8,}$", ErrorMessage = "* At least 8 characters. * No space allowed. * At least 2 alphabets, 1 number, 2 special characters.")]
        public string Password { get; set; }
        [Required]
        [StringLength(148)]
        public string cPassword { get; set; }
    }
}