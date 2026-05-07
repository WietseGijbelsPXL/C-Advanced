namespace LibraryManager.Domain.Results
{
    public class BookResult
    {
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public string? Genre { get; set; }
        public int? Year { get; set; }
        public string? ISBN { get; set; }
    }
}