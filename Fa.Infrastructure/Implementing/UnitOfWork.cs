using Fa.Domain;
using Fa.Infrastructure.Implementing;

namespace Fa.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_dbContext);

        public IAuthorRepository AuthorRepository => _authorRepository ?? new AuthorRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
