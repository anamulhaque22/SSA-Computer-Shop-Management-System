﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address!")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
