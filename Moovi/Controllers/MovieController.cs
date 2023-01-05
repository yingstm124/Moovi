using Microsoft.AspNetCore.Mvc;
using Moovi.Services.Interfaces;

namespace Moovi.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) 
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var moviesView = _movieService.GetMovies();
            return View(moviesView);
        }
    }
}
