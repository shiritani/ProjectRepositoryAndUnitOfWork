using Fa.Domain;

namespace Fa.Infrastructure.Implementing
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
