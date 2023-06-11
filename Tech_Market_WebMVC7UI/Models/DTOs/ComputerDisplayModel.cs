namespace Tech_Market_WebMVC7UI.Models.DTOs
{
    public class ComputerDisplayModel
    {
        public IEnumerable<Computer> Computers { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string STerm { get; set; } = string.Empty;

        public int GenreId { get; set; } = 0;
    }
}
