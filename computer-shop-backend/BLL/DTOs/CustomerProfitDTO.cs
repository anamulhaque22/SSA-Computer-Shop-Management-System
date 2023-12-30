using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerProfitDTO
    {
        [Key]
        public int Id { get; set; }
        public int CusId { get; set; }
        public int TotalProfit { get; set; }
    }
}
