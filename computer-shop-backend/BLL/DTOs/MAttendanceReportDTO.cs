using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MAttendanceReportDTO : ModeratorDTO
    {
        public List<AttendanceReportDTO> AttendanceReports { get; set; }


        public MAttendanceReportDTO()
        {
            AttendanceReports = new List<AttendanceReportDTO>();
        }
    }
}
