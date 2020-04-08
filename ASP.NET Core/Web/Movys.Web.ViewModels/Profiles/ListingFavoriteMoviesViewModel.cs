namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListingFavoriteMoviesViewModel
    {
        public IEnumerable<FavoriteMovieViewModel> Movies { get; set; }
    }
}
