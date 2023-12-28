using System;

namespace Models
{
    internal class AttendanceReport
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateTime { get; set; }
        public int MId { get; set; }
    }
}