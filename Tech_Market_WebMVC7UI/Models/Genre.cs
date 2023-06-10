using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string GenreName { get; set; }
        public List<Computer> Computers { get; set; }
    }
}