using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DiscountDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Coupon { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime ExpireTime { get; set; }
    }
}
