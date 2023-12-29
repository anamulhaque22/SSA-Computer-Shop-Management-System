using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BrandDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
    }
}
