using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Infrastructure.Context
{
    public class Context : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public Context(DbContextOptions<Context> opt) : base(opt) 
        { 
        }

    }
}
