using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int UnitCostPrice { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
