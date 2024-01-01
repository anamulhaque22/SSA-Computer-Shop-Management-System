using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SingleOrderDetailsDTO:OrderGetDTO
    {
        public List<OrderDetailsGetDTO> OrderDetails { get; set; }
        public SingleOrderDetailsDTO()
        {
            OrderDetails = new List<OrderDetailsGetDTO>();
        }
    }
}
