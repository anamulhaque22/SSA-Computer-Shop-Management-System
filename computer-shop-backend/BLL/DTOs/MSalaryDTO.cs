using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MSalaryDTO : ModeratorDTO
    {
        public List<SalaryDTO> salaries { get; set; }

        public MSalaryDTO()
        {
            salaries = new List<SalaryDTO>();
        }
    }
}
