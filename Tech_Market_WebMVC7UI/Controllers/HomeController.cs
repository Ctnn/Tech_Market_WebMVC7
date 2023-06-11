using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tech_Market_WebMVC7UI.Models;
using Tech_Market_WebMVC7UI.Models.DTOs;

namespace Tech_Market_WebMVC7UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm = "",int genreId=0)
        {

            IEnumerable<Computer> computers =await _homeRepository.GetComputers(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            ComputerDisplayModel computerDisplayModel = new ComputerDisplayModel
            {
                Computers = computers,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };
            return View(computerDisplayModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}