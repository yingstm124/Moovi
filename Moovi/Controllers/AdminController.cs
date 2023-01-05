﻿using Microsoft.AspNetCore.Mvc;
using Moovi.Services.Interfaces;
using Moovi.ViewModels;

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
        public IActionResult CreateMovie() 
        {
            var formMovie = new UpsertMovieViewModel()
            {
                Title = ""
            };

            ViewData["FormMovie"] = formMovie;
            return View();
        }
        [HttpPost]
        public IActionResult CreateMovie(UpsertMovieViewModel newMovie) 
        {
            _movieService.UpsertMovie(Guid.Empty, newMovie);
            return Json(new { success = true , message = "Create movie Successful!"});
        }

    }
}