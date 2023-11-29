using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string CategoryName { get; set; }
        public List<string> Suppliers { get; set; }
        public double AllQuantity { get; set; }
        public double DisponibleQuantity { get; set; }
        public double ReservedQuantity { get; set; }
        public List<double> PurchasePrice { get; set; }
        public double Price { get; set; }
        public double TaxValue { get; set; }
        public double ProfitMargin { get; set; }
    }
}
