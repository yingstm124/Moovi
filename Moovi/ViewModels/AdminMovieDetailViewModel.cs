namespace Moovi.ViewModels
{
    public class AdminMovieDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
