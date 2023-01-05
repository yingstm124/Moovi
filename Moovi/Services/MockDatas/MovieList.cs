using Moovi.Models;

namespace Moovi.Repository.MockDatas
{
    public static class MovieList
    {
        static List<Movie> movies;
        static MovieList()
        {
            movies = new List<Movie>()
            {
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = "Avatar 2",
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = "Baymax",
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = "Hobbit",
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = "Harry Potter and the sorcerer's stone",
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
            };
        }

        public static List<Movie> SelectMovieLists()
        {
            return movies;
        }
        public static Movie SelectMovie(Guid movieId) 
        {
            Movie selectMovie = movies.Find(m => m.Id.Equals(movieId));
            return selectMovie;
        }
        public static void InsertMovie(Movie newMovie)
        {
            movies.Add(newMovie);
        }
        public static void EditMovie(Guid movieId, Movie editMovie)
        {
            Movie updateMovie = movies.Find(m => m.Id.Equals(movieId));
            if (updateMovie == null)
                return;
            updateMovie.Title = editMovie.Title;
            updateMovie.FileName = editMovie.FileName;
            updateMovie.FilePath = editMovie.FilePath;
            updateMovie.ModifyDate = DateTime.Now;
        }
        public static void DeleteMovie(Guid movieId)
        {
            Movie removeMovie = movies.Find(m => m.Id.Equals(movieId));
            if (removeMovie == null)
                return;
            movies.Remove(removeMovie);
        }
    }
}
