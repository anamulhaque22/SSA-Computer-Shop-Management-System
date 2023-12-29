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
        [StringLength(148)]
        public string currPassword { get; set; }
        [Required]
        [StringLength(148)]
        public string Password { get; set; }
        [Required]
        [StringLength(148)]
        public string cPassword { get; set; }
    }
}