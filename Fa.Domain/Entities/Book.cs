
namespace Fa.Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int PageNumbers { get; set; }
        public string Genre { get; set; }

        public Guid AuthorId { get; set; }
        public Author   Author { get; set; }
    }
}
