using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MOVIES_DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Movie> Movies { get; set; }


        public void Populate()
        {
            if (!Movies.Any())
            {
                List<Movie> movies = new List<Movie>
            {
            new Movie { MovieId=1, MovieName = "Человек на луне", Description = "Самая опасная миссия в истории", Price = 6, GroupName = "биография"},
            new Movie { MovieId=2, MovieName = "Первому игроку приготовиться", Description = "Загрузи новую реальность", Price = 6, GroupName = "фантастика" },
            new Movie { MovieId=3, MovieName = "Оно", Description = "А чего боишься ты?", Price = 6, GroupName = "ужасы" },
            new Movie { MovieId=4, MovieName = "Убийство в Восточном экспрессе", Description = "Под подозрением каждый", Price = 6, GroupName = "детектив" },
            new Movie { MovieId=5, MovieName = "Малыш на драйве", Description = "Сколько треков нужно для хорошего ограбления?", Price = 6, GroupName = "боевик" },
            new Movie { MovieId=6, MovieName = "Чудо-женщина", Description = "Справедливость наступит вместе с ней", Price = 6, GroupName = "фантастика" },
            };
                Movies.AddRange(movies);
                SaveChanges();
            }


            if (!Roles.Any())
            {
                // Создаем менеджер ролей и пользователей
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

                // Создание роли "admin и "user:
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));

                // Создаем пользователя
                var userAdmin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    NickName = "SuperHero"
                };
                userManager.CreateAsync(userAdmin, "123456").Wait();

                // Добавляем созданного пользователя в администраторы
                userManager.AddToRole(userAdmin.Id, "admin");

            }
        }
        }

}


