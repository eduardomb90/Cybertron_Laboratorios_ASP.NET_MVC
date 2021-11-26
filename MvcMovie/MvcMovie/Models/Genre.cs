using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}