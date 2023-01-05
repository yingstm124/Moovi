using Moovi.ViewModels;

namespace Moovi.Services.Interfaces
{
    public interface IMovieService
    {
        public List<MoviesViewModel> GetMovies();
        public List<AdminMovieViewModel> GetAdminMovies();
        public AdminMovieDetailViewModel GetMovie(Guid movieId);
        public void UpsertMovie(Guid movieId,UpsertMovieViewModel createMovie);
        public void DeleteMovie(Guid movieId);
    }
}
