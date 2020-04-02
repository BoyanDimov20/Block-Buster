namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Web.ViewModels.Reviews;

    public class ListingMoviesViewModel
    {
        public IList<SingleMovieViewModel> Movies { get; set; }

        public int MoviesCount => this.Movies.Count();

        public int PageIndex { get; set; }

        public string Result { get; set; }

        public string Genre { get; set; }

        public double Rating { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
