namespace Movys.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Web.ViewModels.Movies;

    public class HomePageViewModel
    {
        public IEnumerable<MovieViewModel> MostPopularMovies { get; set; }

        public IEnumerable<MovieViewModel> TopRatedMovies { get; set; }

        public IEnumerable<MovieViewModel> MostReviewedMovies { get; set; }

        public IEnumerable<MovieViewModel> ComingSoonMovies { get; set; }

        public IEnumerable<CastMemberViewModel> Celebrities { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
