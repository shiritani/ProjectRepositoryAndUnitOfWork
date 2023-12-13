using Fa.Domain;

namespace Fa.Services
{
    public interface IAuthorService
    {
        List<Author> GetAuthors();
        Author GetAuthor(Guid id);
        void Insert(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
