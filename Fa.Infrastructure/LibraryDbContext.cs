using Fa.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fa.Infrastructure
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
    }
}
