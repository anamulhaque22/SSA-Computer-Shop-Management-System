using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace computerShop.Models
{
    public class AdminUpdateEmailModel
    {
        [Required]
        [StringLength(100)]
        [RegularExpression("^(?=.{1,64}$)[a-z][a-z0-9.-]*[a-z0-9]@[a-z]{2,}(?:\\.[a-z0-9]+)*\\.[a-z]{2,}$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
    }
}