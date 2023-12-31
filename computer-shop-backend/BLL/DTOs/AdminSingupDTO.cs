using computerShop.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminSingupDTO
    {
        [StringLength(16)]
        [RegularExpression("^(?=.*[a-z])[a-z0-9_]{1,16}$", ErrorMessage = "Invalid Username")]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression("^(?=.{1,64}$)[a-z][a-z0-9.-]*[a-z0-9]@[a-z]{2,}(?:\\.[a-z0-9]+)*\\.[a-z]{2,}$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]

        [RegularExpression("^(?=.*[A-Za-z].*[A-Za-z])(?=.*\\d)(?=.*[^A-Za-z\\d\\s].*[^A-Za-z\\d\\s]).{8,}$", ErrorMessage = "* At least 8 characters. * No space allowed. * At least 2 alphabets, 1 number, 2 special characters.")]
        [StringLength(148)]
        public string Password { get; set; }
        [Required]
        [StringLength(148)]
        public string cPassword { get; set; }

        [Required]
        [RegularExpression("^(?=[a-zA-Z])[a-zA-Z ]{1,16}(?: [a-zA-Z ]{0,16})?$", ErrorMessage = "Name can contain only alphabates. And no space is allowed at the beginning.")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(6)]
        [ValidateGender(ErrorMessage = "Invalid Gender")]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(15)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "NID can contain only Numbers.")]
        public string Nid { get; set; }
        [Required]
        [StringLength(11)]
        [RegularExpression("^(017|019|013|018|016|015)\\d{0,10}$", ErrorMessage = "Phone can contain only Numbers.")]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        public string PictureName { get; set; } = null;
        [Required]
        [StringLength(16)]
        public string Key { get; set; }
    }
}
