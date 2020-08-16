namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Movys.Data.Common.Models;

    public class Movie : BaseDeletableModel<string>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ReleaseYear { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public string Country { get; set; }

        public int? Runtime { get; set; }

        public virtual ICollection<MoviesCastMember> CastMembers { get; set; } = new HashSet<MoviesCastMember>();

        public virtual ICollection<MoviesUser> UserWatched { get; set; } = new HashSet<MoviesUser>();

        public virtual ICollection<GenresMovie> Genres { get; set; } = new HashSet<GenresMovie>();

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        public virtual ICollection<Media> MediaUrls { get; set; } = new HashSet<Media>();
    }
}
