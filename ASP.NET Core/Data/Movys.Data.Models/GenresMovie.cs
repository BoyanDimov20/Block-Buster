namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenresMovie
    {
        public string GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
