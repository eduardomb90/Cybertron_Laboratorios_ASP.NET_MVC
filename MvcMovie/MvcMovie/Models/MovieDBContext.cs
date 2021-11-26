using System.Data.Entity;

namespace MvcMovie.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("MovieDbContext")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}