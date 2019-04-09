using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MOVIES_DAL
{
    public class EFMovieRepository : IRepository<Movie>
    {
        private ApplicationDbContext context;
        private DbSet<Movie> table;

        /// <param name="ctx">Контекст базы данных</param>
        public EFMovieRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Movies;
        }

        public void Create(Movie t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new Movie { MovieId = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Movie> Find(Func<Movie, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public Movie Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return table;
        }

        public Task<Movie> GetAsync(int id)
        {
            return table.FindAsync(id);
        }

        public void Update(Movie t)
        {
            // если изображение не загружено, // то использовать изображение из базы данных 
            if (t.Image==null)
            {
                var dish = context.Movies
                    .AsNoTracking()
                    .Where(d => d.MovieId == t.MovieId)                       
                    .FirstOrDefault();
                t.Image = dish.Image;
                t.MimeType = dish.MimeType;
            }

            context.Entry<Movie>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
