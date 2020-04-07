namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;
    using Movys.Web.ViewModels.Reviews;

    public class MovieViewModel : IMapFrom<Movie>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        public double Rating => (this.Reviews.Count() == 0) ? 0 : this.Reviews.Average(x => x.Rating);

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        public IEnumerable<CastMemberViewModel> CastMembers { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
