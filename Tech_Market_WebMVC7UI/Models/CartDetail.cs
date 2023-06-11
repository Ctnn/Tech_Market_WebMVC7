using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("Cart")]
    public class CartDetail
    {
        public int Id { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public int ComputerId { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }

        public Computer Computer { get; set; }

        [ForeignKey("ShoppingCartId")]
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
