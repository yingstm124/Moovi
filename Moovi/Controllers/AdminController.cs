using Microsoft.AspNetCore.Mvc;
using Moovi.Services.Interfaces;
using Moovi.ViewModels;
using System;

namespace Moovi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService) 
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var adminMovies = _movieService.GetAdminMovies();
            return View(adminMovies);
        }
        public IActionResult DetailMovie(Guid id) 
        {
            var adminDetailMovie = _movieService.GetMovie(id);
            return View(adminDetailMovie);
        }
        public IActionResult UpsertMovie(Guid? id) 
        {
            if (id.HasValue)
            {
                var existingMovie = _movieService.GetMovie(id.Value);
                var formMovie = new UpsertMovieViewModel()
                {
                    Id = id.Value,
                    Title = existingMovie.Title,
                    FileName = existingMovie.FileName,
                    FilePath = existingMovie.FilePath
                };
                return View(formMovie);
            }
            else 
            {
                var formMovie = new UpsertMovieViewModel()
                {
                    Id = Guid.Empty,
                    Title = ""
                };
                return View(formMovie);

            }
        }
        
        [HttpPost]
        public IActionResult UpsertMovie(UpsertMovieViewModel upsertMovie) 
        {
            if (ModelState.IsValid) 
            {
                _movieService.UpsertMovie(upsertMovie.Id, upsertMovie);
                return RedirectToAction(nameof(Index));
            }
            return View(upsertMovie);
        }
        public IActionResult DeleteMovie(Guid id) 
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
