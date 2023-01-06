using System.ComponentModel.DataAnnotations;

namespace Moovi.ViewModels
{
    public class UpsertMovieViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "I need it")]
        public string Title { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}
