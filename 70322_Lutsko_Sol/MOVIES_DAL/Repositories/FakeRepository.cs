using MOVIES_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIES_DAL
{
    public class FakeRepository : IRepository<Movie>
    {
        public void Create(Movie t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> Find(Func<Movie, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Movie Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return new List<Movie>
            {
            new Movie { MovieId=1, MovieName = "Человек на луне", Description = "Самая опасная миссия в истории", Price = 6, GroupName = "биография"},
            new Movie { MovieId=2, MovieName = "Первому игроку приготовиться", Description = "Загрузи новую реальность", Price = 6, GroupName = "фантастика" },
            new Movie { MovieId=3, MovieName = "Оно", Description = "А чего боишься ты?", Price = 6, GroupName = "ужасы" },
            new Movie { MovieId=4, MovieName = "Убийство в Восточном экспрессе", Description = "Под подозрением каждый", Price = 6, GroupName = "детектив" },
            new Movie { MovieId=5, MovieName = "Малыш на драйве", Description = "Сколько треков нужно для хорошего ограбления?", Price = 6, GroupName = "боевик" },
            new Movie { MovieId=6, MovieName = "Чудо-женщина", Description = "Справедливость наступит вместе с ней", Price = 6, GroupName = "фантастика" },
            new Movie { MovieId=7, MovieName = "Чудо-женщина", Description = "Справедливость наступит вместе с ней", Price = 6, GroupName = "фантастика" },
            new Movie { MovieId=8, MovieName = "Чудо-женщина", Description = "Справедливость наступит вместе с ней", Price = 6, GroupName = "фантастика" },
            new Movie { MovieId=9, MovieName = "Чудо-женщина", Description = "Справедливость наступит вместе с ней", Price = 6, GroupName = "фантастика" },
            new Movie { MovieId=10, MovieName = "Чудо-женщина", Description = "Справедливость наступит вместе с ней", Price = 6, GroupName = "фантастика" },
            };
        }

        public Task<Movie> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
