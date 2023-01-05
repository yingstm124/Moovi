using Moovi.Models;
using Moovi.Repository.MockDatas;
using Moovi.Services.Interfaces;
using Moovi.ViewModels;

namespace Moovi.Services
{
    public class MovieService : IMovieService
    {        
        public List<MoviesViewModel> GetMovies()
        {
            var movies = MovieList.SelectMovieLists();
            return movies.Select(m => new MoviesViewModel() 
            { 
                Id = m.Id,
                Title = m.Title,
                FileName = m.FileName,
                FilePath = m.FilePath,
            }).ToList();
        }
        public AdminMovieDetailViewModel GetMovie(Guid movieId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
