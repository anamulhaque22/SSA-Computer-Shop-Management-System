using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TotalSaleDTO
    {
        [Key]
        public int Id { get; set; }
        [DefaultValue(0)]
        public int Jan { get; set; } = 0;
        [DefaultValue(0)]
        public int Feb { get; set; } = 0;
        [DefaultValue(0)]
        public int Mar { get; set; } = 0;
        [DefaultValue(0)]
        public int Apr { get; set; } = 0;
        [DefaultValue(0)]
        public int May { get; set; } = 0;
        [DefaultValue(0)]
        public int Jun { get; set; } = 0;
        [DefaultValue(0)]
        public int Jul { get; set; } = 0;
        [DefaultValue(0)]
        public int Aug { get; set; } = 0;
        [DefaultValue(0)]
        public int Sep { get; set; } = 0;
        [DefaultValue(0)]
        public int Oct { get; set; } = 0;
        [DefaultValue(0)]
        public int Nov { get; set; } = 0;
        [DefaultValue(0)]
        public int Dec { get; set; } = 0;
    }
}
