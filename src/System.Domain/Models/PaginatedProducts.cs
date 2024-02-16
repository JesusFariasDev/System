using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Models
{
    public class PaginatedProducts
    {
        public int? ProductsCount { get; set; }
        public int? TotalPages { get; set; }
        public List<Product?> Products { get; set;}
    }
}
