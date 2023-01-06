using Microsoft.AspNetCore.Mvc;
using Moovi.Models;
using Moovi.Repository.MockDatas;
using Moovi.Services.Interfaces;
using Moovi.ViewModels;

namespace Moovi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IWebHostEnvironment _webHostEnv;
        public MovieService(IWebHostEnvironment webHostEnv) 
        {
            _webHostEnv = webHostEnv;
        }
        public List<MoviesViewModel> GetMovies()
        {
            var movies = MovieList.SelectMovieLists();
            var displayImage = Path.Combine(_webHostEnv.WebRootPath, "uploads/movies");
            DirectoryInfo directoryInfo = new DirectoryInfo(displayImage);
            FileInfo[] fileInfo = directoryInfo.GetFiles();

            return movies.Select(m => new MoviesViewModel() 
            { 
                Id = m.Id,
                Title = m.Title            
            }).ToList();
        }
        public AdminMovieDetailViewModel GetMovie(Guid movieId)
        {
            var movie = MovieList.SelectMovie(movieId);
            if (movie == null)
                throw new InvalidDataException("");
            return new AdminMovieDetailViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                FileName = movie.FileName,
                FilePath = movie.FilePath,
                CreatedDate = movie.CreatedDate,
                ModifyDate = movie.ModifyDate,
            };
        }

        public void UpsertMovie(Guid movieId ,UpsertMovieViewModel upsertMovie)
        {
            if (Guid.Empty.Equals(movieId))
                MovieList.InsertMovie(new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = upsertMovie.Title,
                    FileName = upsertMovie.FileName,
                    FilePath = upsertMovie.FilePath,
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });
            else
                MovieList.EditMovie(movieId, new Movie()
                {
                    Title = upsertMovie.Title,
                    FileName = upsertMovie.FileName,
                    FilePath = upsertMovie.FilePath,
                    ModifyDate = DateTime.Now
                });
        }

        public void DeleteMovie(Guid movieId)
        {
            MovieList.DeleteMovie(movieId);
        }

        public List<AdminMovieViewModel> GetAdminMovies()
        {
            var movies = MovieList.SelectMovieLists();
            return movies.Select(m => new AdminMovieViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                FileName = m.FileName,
                FilePath = m.FilePath,
                CreatedDate = m.CreatedDate,
                ModifyDate = m.ModifyDate
            }).ToList();
        }
    }
}
