using Fa.Domain;
using Fa.Services;
using Fa.WebApp20231130.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fa.WebApp20231130.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: AuthorsController
        public ActionResult Index()
        {
            var authors = _authorService.GetAuthors();
            var authorVms = new List<AuthorVm>();

            foreach (var author in authors)
            {
                authorVms.Add(new AuthorVm()
                {
                    Id = author.Id,
                    AuthorName = author.AuthorName,
                });
            }

            return View(authorVms);
        }

        // GET: AuthorsController/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                var author = _authorService.GetAuthor(new Guid(id));
                if(author!=null)
                {
                    var authorVm = new AuthorVm() { Id = author.Id, AuthorName = author.AuthorName };
                    
                    return View(authorVm);
                }
            }
            catch 
            {
            }
            return RedirectToAction("Index");
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {//string authorName, IFormCollection, AuthorVm 
                var authorName = collection["AuthorName"].ToString();

                _authorService.Insert(new Author() { AuthorName = authorName });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                var author = _authorService.GetAuthor(new Guid(id));
                var authorVm = new AuthorVm() { AuthorName = author.AuthorName };
                if (authorVm != null)
                {
                    return View(authorVm);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorVm authorVm)
        {
            try
            {
                var author = new Author() { Id = authorVm.Id, AuthorName = authorVm.AuthorName };
                _authorService.Update(author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                var author = _authorService.GetAuthor(new Guid(id));
                if (author != null) 
                    _authorService.Delete(author);
            }
            catch 
            {
            }
            return RedirectToAction("Index");
        }

        
    }
}
