using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOVIES_DAL;
using _70322_Lutsko.Models;

namespace _70322_Lutsko.Controllers
{
    public class InfoController : Controller
    {
        readonly int pageSize = 3;

        IRepository<Movie> repository;
            public InfoController(IRepository<Movie> repo)
            {
                repository = repo;
            }
        // GET: Info
        public ActionResult Index(string group, int page = 1)
        {
            var lst = repository.GetAll()
                .Where(d => group == null
                || d.GroupName.Equals(group));
                
            var model = PageListViewModel<Movie>.CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            var movie = repository.Get(id);
            if (movie != null)
            {
                return new FileContentResult(movie.Image, movie.MimeType);
            }
            else return null;
        }
    }
}