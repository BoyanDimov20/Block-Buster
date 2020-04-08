namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class FavoriteMovieViewModel : IMapFrom<MoviesUser>
    {
        public string UserId { get; set; }

        public string MovieId { get; set; }

        public string MovieTitle { get; set; }

        public string MovieImageUrl { get; set; }

        public string MovieReleaseYear { get; set; }

        public string MovieDescription { get; set; }

    }
}
