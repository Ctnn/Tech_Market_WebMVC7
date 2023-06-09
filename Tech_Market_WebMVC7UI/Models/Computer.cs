using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("Computer")]
    public class Computer
    {
      
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? ComputerName { get;set; } 

        public string? Image { get; set; }  

        public string GenreId { get;set; }

        public required Genre Genre;
    }
}
