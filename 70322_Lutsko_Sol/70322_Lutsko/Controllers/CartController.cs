using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOVIES_DAL;
using _70322_Lutsko.Models;

namespace _70322_Lutsko.Controllers
{
    public class CartController : Controller
    {
        IRepository<Movie> repository;
        // GET: Cart
        public CartController(IRepository<Movie> repo)
        {
            repository = repo;
        }

        /// <summary> 
        /// Получение корзины из сессии ]
        /// </summary>]
        /// <returns></returns> 
        /// 
        public Cart GetCart()
        {
            Cart cart = Session["сart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["сart"] = cart;
            }
            return cart;
        }

        [Authorize]
        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }

        /// <summary> 
        /// Добавление товара в корзину
        /// </summary> 
        /// <param name="id">id добавляемого элемента</param> 
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
            {
                GetCart().AddItem(item);
                ViewBag.MessageCart = string.Format("Успешно добавлен элемент: {0}", item.MovieName);
            }
            ViewBag.MessageCart = "Элемент не был добавлен";
            return Redirect(returnUrl);
        }

        //Вывод общей информации о корзине в заголовке страницы
        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }
    }
}