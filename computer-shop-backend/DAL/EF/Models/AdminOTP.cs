using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class AdminOTP
    {
        [Key]
        public int Id { get; set; }
        public string Otp { get; set; }
        public string Username { get; set; }
    }
}
