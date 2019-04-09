using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _70322_Lutsko
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1я страница списка фильмов
            routes.MapRoute(
            name: "",
            url: "movies",
            defaults: new
            {
                controller = "Info",
                action = "Index",
                page = 1,
                group = (string)null
            });

            //N страница списка фильмов
            routes.MapRoute(
            name: "",
            url: "movies/page{page}",
            defaults: new
            {
                controller = "Info",
                action = "Index",
                group = (string)null
            },
            constraints: new { page = @"\d+" });

            //1я страница списка блюд по выбранной группе блюд
            routes.MapRoute(
            name: "",
            url: "movies/{group}",
            defaults: new
            {
                controller = "Info",
                action = "index",
                page = 1
            });

            //N страница списка блюд по выбранной группе блюд
            routes.MapRoute(
            name: "",
            url: "movies/{group}/page{page}",
            defaults: new { controller = "Info", action = "Index" },
            constraints: new { page = @"\d+" });

            //маршрут по умолчанию
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
