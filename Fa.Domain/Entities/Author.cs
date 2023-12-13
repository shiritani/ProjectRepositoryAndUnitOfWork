namespace Fa.Domain
{
    public class Author: BaseEntity
    {
        public string AuthorName { get; set; }
        public List<Book> Books { get; set; }
    }
}
