using Microsoft.AspNetCore.Mvc;
using Moovi.Services.Interfaces;

namespace Moovi.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMovieService _movieService;

        public MovieController(IWebHostEnvironment webHostEnvironment, IMovieService movieService) 
        {
            _movieService = movieService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var moviesView = _movieService.GetMovies();

            // manipulate file path
            moviesView = moviesView.Select(m =>
            {
                m.FilePath = "~/uploads/movies/avatar2.jpg";
                return m;
            }).ToList();
            return View(moviesView);
        }
    }
}
