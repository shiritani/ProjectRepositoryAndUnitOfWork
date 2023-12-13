using Fa.Domain;
using Fa.Infrastructure;

namespace Fa.Services
{
    public class BookService : IBookService
    {
        public IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Book book)
        {
            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.Commit();   
        }

        public void Delete(Book book)
        {
            _unitOfWork.BookRepository.Remove(book);
            _unitOfWork.Commit();
        }

        public IEnumerable<Book> GetAll()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        public Book GetBook(Guid id)
        {
            return _unitOfWork.BookRepository.Get(b => b.Id == id);
        }

        public void Update(Book book)
        {
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Commit();
        }
    }
}
