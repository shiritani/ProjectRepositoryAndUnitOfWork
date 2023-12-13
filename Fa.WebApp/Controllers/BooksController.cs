using Fa.Services;
using Fa.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Fa.WebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            List<BookVm> bookVms = new List<BookVm>();

            foreach (var book in books)
            {
                bookVms.Add(new BookVm()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PageNumbers = book.PageNumbers,
                    Genre = book.Genre
                });
            }
            //pass data to view: Model
            return View(bookVms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, int pageNumbers, string genre)
        {
            _bookService.Add(new Domain.Book()
            {
                Title = title,
                PageNumbers = pageNumbers,
                Genre = genre
            });
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var book = _bookService.GetBook(new Guid(id));
            if (book != null)
            {
                BookVm bookVm = new BookVm
                {
                    Id = book.Id,
                    Title = book.Title,
                    PageNumbers = book.PageNumbers,
                    Genre = book.Genre
                };

                return View(bookVm);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(string id,string title, int pageNumbers, string genre)
        {
            var book = _bookService.GetBook(new Guid(id));
            if (book != null)
            {
                book.Title = title;
                book.PageNumbers = pageNumbers;
                book.Genre = genre;

                _bookService.Update(book);  
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var book = _bookService.GetBook(new Guid(id));

            if (book != null)
            {
                _bookService.Delete(book);
            }
            return RedirectToAction("Index");
        }
    }
}
