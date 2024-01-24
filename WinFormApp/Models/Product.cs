using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormApp.Models
{
    [Table("Product")]
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
