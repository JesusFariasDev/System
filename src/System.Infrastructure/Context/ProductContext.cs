using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Infrastructure.Context
{
    public class ProductContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt) 
        { 
        }

    }
}
