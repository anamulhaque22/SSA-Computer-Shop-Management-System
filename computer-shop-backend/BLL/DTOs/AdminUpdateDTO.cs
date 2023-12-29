﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminUpdateDTO
    {
        [StringLength(16)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string Password { get; set; } = null;

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(6)]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(15)]
        public string Nid { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        public string PictureName { get; set; } = null;
    }
}
