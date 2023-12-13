using Fa.Domain;
using Fa.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Fa.Services.Tests
{
    public class BookServiceTests
    {
        //setup dbContextOptions fake db
        private static DbContextOptions<LibraryDbContext> _options
            = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: "dbTests").Options;

        private LibraryDbContext _dbContext;
        private IUnitOfWork unitOfWork;
        private IBookService bookService;

        [OneTimeSetUp]
        public void Setup()
        {
            _dbContext = new LibraryDbContext(_options);
            _dbContext.Database.EnsureCreated();
            SeedDatabase();

            unitOfWork = new UnitOfWork(_dbContext);
            bookService = new BookService(unitOfWork);
        }

        private void SeedDatabase()
        {
            var books = new List<Book>()
            {
                new Book(){Title="Title 1",PageNumbers=100,Genre="Genre 1"},
                new Book(){Title="Title 2",PageNumbers=200,Genre="Genre 1"},
                new Book(){Title="Title 3",PageNumbers=300,Genre="Genre 2"},
              //  new Book(){Title="Title 3",PageNumbers=300,Genre="Genre 2"}
            };

            _dbContext.Books.AddRange(books);
            _dbContext.SaveChanges();
        }

        [Test]
        public void GetAll_GetAllRecordsInDb_ReturnAllRecord()
        {
            var books = bookService.GetAll();

            var expected = 3;

            Assert.That(books.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InsertSuccess()
        {
            var book = new Book()
            {
                Title = "Title 3",
                PageNumbers = 300,
                Genre = "Genre 2"
            };

            bookService.Add(book);

            var expected = _dbContext.Books.Count();

            Assert.That(expected, Is.EqualTo(4));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}