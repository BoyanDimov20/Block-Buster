namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenresTVShow
    {
        public string GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public string TVShowId { get; set; }

        public virtual TVShow TVShow { get; set; }
    }
}
