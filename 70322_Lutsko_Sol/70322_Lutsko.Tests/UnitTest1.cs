using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOVIES_DAL;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;
using _70322_Lutsko.Models;
using _70322_Lutsko.Controllers;

namespace _70322_Lutsko.Tests
{
    [TestClass]
    public class DishControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Movie>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Movie>
                {
                    new Movie{MovieId = 1, MovieName = "Movie1"},
                    new Movie {MovieId = 2, MovieName = "Movie2"},
                    new Movie {MovieId = 3, MovieName = "Movie3"},
                    new Movie {MovieId = 4, MovieName = "Movie4"},
                    new Movie {MovieId = 5, MovieName = "Movie5"},
                });

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание объекта контроллера
            var controller = new InfoController(mock.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода List
            var view = controller.Index(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Movie> model = view.Model as PageListViewModel<Movie>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].MovieId);
            Assert.AreEqual(5, model[1].MovieId);
        }
        [TestMethod]
        public void CategoryTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Movie>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Movie>
                {
                    new Movie{MovieId = 1, MovieName = "Movie1", GroupName = "1"},
                    new Movie {MovieId = 2, MovieName = "Movie2", GroupName = "2"},
                    new Movie {MovieId = 3, MovieName = "Movie3", GroupName = "1"},
                    new Movie {MovieId = 4, MovieName = "Movie4", GroupName = "2"},
                    new Movie {MovieId = 5, MovieName = "Movie5", GroupName = "2"},
                });

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание объекта контроллера
            var controller = new InfoController(mock.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода List
            var view = controller.Index("1", 1) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Movie> model = view.Model as PageListViewModel<Movie>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].MovieId);
            Assert.AreEqual(3, model[1].MovieId);

        }
        [TestMethod]
        public void DefaultRouteTest()
        {
            // Arrange
            // Макет Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
                .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");

            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            // Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }
    }
}
