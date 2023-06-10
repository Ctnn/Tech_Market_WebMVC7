using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("Computer")]
    public class Computer
    {
      
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string? ComputerName { get;set; }
        [Required]
        [MaxLength(40)]
        public string? CompanyName { get; set; }


        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string GenreName { get; set; }

    }
}
