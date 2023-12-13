using Fa.Domain;

namespace Fa.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Author author)
        {
            _unitOfWork.AuthorRepository.Remove(author);
            _unitOfWork.Commit();
        }

        public Author GetAuthor(Guid id)
        {
            return _unitOfWork.AuthorRepository.Get(a => a.Id == id);
        }

        public List<Author> GetAuthors()
        {
            return _unitOfWork.AuthorRepository.GetAll().ToList();
        }

        public void Insert(Author author)
        {
            _unitOfWork.AuthorRepository.Add(author);   
            _unitOfWork.Commit();
        }

        public void Update(Author author)
        {
            _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Commit();
        }
    }
}
