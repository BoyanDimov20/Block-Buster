namespace Movys.Data.Models
{
    using System.Collections.Generic;

    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public int ReviewsCount { get; set; }

        public ICollection<CastMember> Directors { get; set; }

        public ICollection<CastMember> Writers { get; set; }

        public ICollection<CastMember> Stars { get; set; } = new HashSet<CastMember>();

    }
}
