namespace Fa.WebApp20231130.Models
{
    public class BookVm
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public int PageNumbers { get; set; }
        public string Genre { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
