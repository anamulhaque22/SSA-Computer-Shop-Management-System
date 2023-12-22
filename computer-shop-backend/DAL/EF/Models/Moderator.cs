using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Moderator
    {


        [Key]
        
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


        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<AttendanceReport> AttendanceReports { get; set; }



        public Moderator()
        {
            Salaries = new List<Salary>();
            AttendanceReports = new List<AttendanceReport>();
        }
    }
}
