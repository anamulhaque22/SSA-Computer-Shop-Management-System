using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SalaryDTO
    {
        public int Id { get; set; }
        [Required]
        public string MonthName { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Amount { get; set; }
        public int ReportedBy { get; set; }
    }
}
