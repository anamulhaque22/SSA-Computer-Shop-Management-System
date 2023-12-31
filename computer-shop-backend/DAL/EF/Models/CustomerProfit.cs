﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CustomerProfit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CusId { get; set; }
        public int TotalProfit { get; set; } = 0;
    }
}
