using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Models
{
    [Table("TB_PRODUCTS")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Category { get; set; }
        public double? AllQuantity { get; set; }
        public double? DisponibleQuantity { get; set; }
        public double? ReservedQuantity { get; set; }
        public double? PurchasePrice { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public double? Price { get; set; }
        public double? TaxValue { get; set; }
        public double? ProfitMargin { get; set; }
    }
}
