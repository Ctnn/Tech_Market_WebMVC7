
using Microsoft.EntityFrameworkCore;

namespace Tech_Market_WebMVC7UI.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db) {
            _db = db;
        } 
        public async Task<IEnumerable<Computer>> GetComputers(string sTerm="",int genreId=0)
        {
            sTerm = sTerm.ToLower();
               IEnumerable<Computer> computers = await (from computer in _db.Computers
                                 join genre in _db.Genres
                                 on computer.GenreId equals genre.Id
                                where string.IsNullOrWhiteSpace(sTerm) || (computer !=null && computer.ComputerName.ToLower().StartsWith(sTerm))
                                 select new Computer
                                 { Id = computer.Id,
                                   Image = computer.Image,
                                   CompanyName = computer.CompanyName,
                                   ComputerName = computer.ComputerName,
                                   GenreId = computer.GenreId,
                                   Price = computer.Price,
                                   GenreName= genre.GenreName
                                 }).ToListAsync();

            if (genreId > 0)
            {
                computers = computers.Where(a => a.GenreId == genreId).ToList(); 

            }
            return computers;
        }
    }
}
