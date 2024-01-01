using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderGetDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string OrderAddress { get; set; }
        public string OrderNote { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
