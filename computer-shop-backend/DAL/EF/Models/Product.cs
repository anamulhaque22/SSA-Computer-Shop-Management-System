using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product name is require!")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int ProductPrice { get; set; }

        [Required]
        public int CostPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string PublicImageId { get; set; }



        [Required]
        [Column(TypeName ="text")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
