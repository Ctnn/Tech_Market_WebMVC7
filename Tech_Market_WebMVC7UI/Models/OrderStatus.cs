using System.ComponentModel.DataAnnotations;

namespace Tech_Market_WebMVC7UI.Models
{
    public class OrderStatus
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string ?StatusName { get; set; }

    }
}
