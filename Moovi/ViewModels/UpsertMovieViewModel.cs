using System.ComponentModel.DataAnnotations;

namespace Moovi.ViewModels
{
    public class UpsertMovieViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is require!")]
        public string Title { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public IFormFile? Formfile { get; set; }
    }
}
