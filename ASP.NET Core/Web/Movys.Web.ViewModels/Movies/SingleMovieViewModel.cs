namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;
    using Movys.Web.ViewModels.Reviews;
    using Movys.Web.ViewModels.Users;

    public class SingleMovieViewModel : IMapFrom<Movie>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public int ReviewsCount => this.Reviews.Count();

        public bool IsAddedToFavorite { get; set; }

        public double Rating => (this.ReviewsCount == 0) ? 0 : this.Reviews.Average(x => x.Rating);

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        public IEnumerable<CastMemberViewModel> CastMembers { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public IEnumerable<MediaViewModel> MediaUrls { get; set; }

        public IEnumerable<MovieViewModel> RelatedMovies { get; set; }

        public ReviewFormInputModel ReviewFormInputModel { get; set; } = new ReviewFormInputModel();

        public ReviewViewModel MostRecentReview => this.Reviews.OrderByDescending(x => x.CreatedOn).First();
    }
}
