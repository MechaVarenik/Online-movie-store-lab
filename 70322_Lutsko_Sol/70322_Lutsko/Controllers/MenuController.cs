using _70322_Lutsko.Models;
using MOVIES_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _70322_Lutsko.Controllers
{

    public class MenuController : Controller
    {
        private List<MenuItem> items;
        IRepository<Movie> repository;

        public MenuController(IRepository<Movie> repo)
        {
            repository = repo;
            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home",
                Action="Index", Active=string.Empty},
                new MenuItem{Name="Cписок фильмов", Controller="Info",
                Action="Index", Active=string.Empty},
                new MenuItem{Name="Администрирование", Controller="Admin",
                Action="Index", Active=string.Empty},
            };
        }

        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            if (items.Where(t => t.Controller == c).Count() > 0)
            {
                items.First(m => m.Controller == c).Active = "active";
            }
            return PartialView(items);
        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }
        public PartialViewResult Side()
        {

            var groups = repository.GetAll()
            .Select(d => d.GroupName)
            .Distinct();


            var x = groups.ToList();


            return PartialView(groups);
        }
        public PartialViewResult Map(string a = "Index", string c = "Home")
        {
            items.First(m => m.Controller == c).Active = "active"; return PartialView(items);
        }
        // GET: Menu
        public ActionResult Index()
        {
          return View();
        }

    }
   
}