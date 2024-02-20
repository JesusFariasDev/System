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
        public decimal? AllQuantity { get; set; }
        public decimal? DisponibleQuantity { get; set; }
/*        public DateTime? BestBefore { get; set; }
*/        public decimal? ReservedQuantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public decimal? Price { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? ProfitMargin { get; set; }
    }
}
