using FirstMVCApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class AuthorController : Controller
    {
        // GET: AuthorControllercs
        public ActionResult Index()
        {
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary();
            if(list != null && list.Count>0)
            {
                return View("AuthorList", list.Values.ToList());
            }
                
            return View();
        }

        // GET: AuthorControllercs/Details/5
        public ActionResult Details(int id)
        {
            Author author = AuthorRepository.FindAuthorByID(id);
            if(author != null)
            {
                return View(author);
            }
            return RedirectToAction("Index");
        }

        // GET: AuthorControllercs/Create
        public ActionResult Create()
        {
            Author author = new Author();
            return View(author);
        }

        // POST: AuthorControllercs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Author pAuthor)
        {
            try
            {
                AuthorRepository.SaveToFile(pAuthor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            Author author = AuthorRepository.FindAuthorByID(id);
            if(author != null)
            {
                return View(author);
            }
            return View(author);
        }

        // POST: AuthorControllercs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Author pAuthor)
        {
            try
            {
                AuthorRepository.UpdateAuthorToFile(pAuthor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            Author author = AuthorRepository.FindAuthorByID(id);
            if(author != null)
            {
                return View(author);
            }
            return View(author);
        }

        // POST: AuthorControllercs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Author pAuthor)
        {
            try
            {
                AuthorRepository.RemoveAuthor(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
