using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class AdminToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Tkey { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
        
        //[ForeignKey("Username")]
        public string Username { get; set; }
        //public virtual Admin Admin { get; set; }
    }
}
