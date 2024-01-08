using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Models
{
    [Table("TB_CUSTOMERS")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Document {  get; set; }
        [Required]
        public string DocType { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurnameName { get; set; }
        [Required] 
        public string Address { get; set; }
        [Required]
        public string AddressNumber { get; set; }
        [Required]
        public string AddressComplement { get; set; }
        [Required]
        public string AddressCity { get; set; }
        [Required]
        public string AddressProvince { get; set; }
        [Required]
        public string AddressCountry { get; set; }
        [Required]
        public string PostalCode { get; set; }

    }
}
