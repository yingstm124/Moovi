using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Moovi.Services.Interfaces;
using Moovi.ViewModels;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Moovi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IHostingEnvironment _environment;

        public AdminController(IHostingEnvironment environment, IMovieService movieService)
        {
            _movieService = movieService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var adminMovies = _movieService.GetAdminMovies();
            // manipulate file path
            adminMovies = adminMovies.Select(m =>
            {
                m.FilePath = "~/uploads/movies/avatar2.jpg";
                return m;
            }).ToList();

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
                if(upsertMovie.Formfile != null)
                    UploadMovieImage(upsertMovie.Formfile);

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

        private void UploadMovieImage(IFormFile targetFile) 
        {
            string wwwPath = _environment.WebRootPath;
            string path = Path.Combine(wwwPath, "uploads/movies");

            // upload file in folder
            string fileName = Path.GetFileName(targetFile.FileName);
            using (FileStream strem = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                targetFile.CopyTo(strem);

            }
        }
    }
}
