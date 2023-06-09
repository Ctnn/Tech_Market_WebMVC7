using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {

        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ComputerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public Order Order { get; set; }
        public Computer Computer { get; set; }

    }
}
