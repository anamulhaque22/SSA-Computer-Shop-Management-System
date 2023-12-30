﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CustomerToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Tkey { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string Email { get; set; }
    }
}
