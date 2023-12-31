using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nid { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set;}
        public string Post { get; set; }
        public int Salary { get; set; }
        public int CurrentRating { get; set; } = 0;
        public string PictureName { get; set; }
        public int Otp { get; set; }
        public int OtpVerified { get; set; } = 0;
        public int AdminApproval { get; set; } = 0;
    }
}
