using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Criteria
{
    public class ProductFilterCriteria
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public bool? InStock { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // Sorting direction: true for ascending, false for descending
        public bool SortAscending { get; set; }

        // Pagination properties
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
