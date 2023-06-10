namespace Tech_Market_WebMVC7UI
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Computer>> GetComputers(string sTerm = "", int genreId = 0);
    }
}