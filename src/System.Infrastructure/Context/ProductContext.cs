using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Infrastructure.Context
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt) 
        { 
        }

    }
}
