using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AttendanceReportDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string EmployeeName { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public int MId { get; set; }
    }
}
