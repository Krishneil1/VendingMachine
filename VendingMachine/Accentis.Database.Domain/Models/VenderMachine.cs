using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentis.Database.Domain.Models
{
    public class VenderMachine : BaseEntity
    {
        [Key]        
        public Guid ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is required!!!")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Quantity is required!!!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter price per item!!!")]
        public double PerItemPrice { get; set; }
        public int SoldQuantity { get; set; }
        public double Collection { get; set; }
    }
}
