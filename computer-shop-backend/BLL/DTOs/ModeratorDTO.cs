using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ModeratorDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Ename { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        public string Post { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
