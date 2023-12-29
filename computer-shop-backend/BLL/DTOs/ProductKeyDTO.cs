using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductKeyDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public string Key { get; set; }
    }
}
