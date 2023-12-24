using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductCategoryBrandDTO:ProductDTO
    {
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }
}
