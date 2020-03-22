namespace Movys.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Movys.Data.Common.Models;

    public class Movie : BaseDeletableModel<string>
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public int ReviewsCount { get; set; }

        public ICollection<MoviesCastMember> CastMembers { get; set; } = new HashSet<MoviesCastMember>();

        public ICollection<MoviesUser> UserWatched { get; set; } = new HashSet<MoviesUser>();
    }
}
