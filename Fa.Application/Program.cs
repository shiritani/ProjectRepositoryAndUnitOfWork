using Fa.Domain;
using Fa.Infrastructure;
using Fa.Services;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
optionsBuilder.UseSqlServer("server=HOANG;database=LibraryDb;TrustServerCertificate=True");

using (LibraryDbContext dbContext = new LibraryDbContext(optionsBuilder.Options)) {
    IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
    IBookService bookService = new BookService(unitOfWork);

    //bookService.Add(new Book() { Title = "Title1", PageNumbers = 100, Genre = "Genre1" });
    //bookService.Add(new Book() { Title = "Title2", PageNumbers = 200, Genre = "Genre1" });

    var books = bookService.GetAll();
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id} | {book.Title} | {book.PageNumbers} | {book.Genre}");
    }
}
    
