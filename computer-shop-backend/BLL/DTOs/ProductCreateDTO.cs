using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductCreateDTO:ProductDTO
    {
        public int CostPrice { get; set; }
        public string FileName { get; set; }
        public Stream FileData { get; set; }
    }
}
