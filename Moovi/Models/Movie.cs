using System.ComponentModel.DataAnnotations;

namespace Moovi.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
