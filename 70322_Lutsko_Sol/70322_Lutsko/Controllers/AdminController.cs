using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOVIES_DAL;

namespace _70322_Lutsko.Controllers
{
    public class AdminController : Controller
    {
        IRepository <Movie> repository;

        public AdminController(IRepository <Movie> repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            var list = repository.GetAll();
            return View(list);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Movie());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Movie movie, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    movie.Image = new byte[count];
                    imageUpload.InputStream.Read(movie.Image, 0, (int)count);
                    movie.MimeType = imageUpload.ContentType;
                }
                try
                {
                    // TODO: Add insert logic here
                    repository.Create(movie);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(movie);
                }
            }
            else return View(movie);
            }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movie, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    movie.Image = new byte[count];
                    imageUpload.InputStream.Read(movie.Image, 0, (int)count);
                    movie.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Update(movie);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(movie);
                }
            }
            else return View(movie);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movie);
            }
        }
    }
}
