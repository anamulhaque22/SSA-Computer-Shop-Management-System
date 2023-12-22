using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
   public class Salary
    {
        public int Id { get; set; }
        [Required]
        public string MonthName { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Amount { get; set; }
        [ForeignKey("Moderator")]
        public int ReportedBy { get; set; }

        public virtual Moderator Moderator { get; set; }


    }
}
