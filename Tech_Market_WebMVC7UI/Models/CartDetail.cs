using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("Cart")]
    public class CartDetail
    {
        public int Id { get; set; }

        [Required]
        public int ShoppingCart_Id { get; set; }

        [Required]
        public int ComputerId { get; set; }

        [Required]
        public int Quantitiy { get; set; }

 
        public Computer Computer { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
