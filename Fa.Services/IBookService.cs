using Fa.Domain;

namespace Fa.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetBook(Guid id);
        void Add(Book book);

        void Update(Book book);
        void Delete(Book book);
    }
}