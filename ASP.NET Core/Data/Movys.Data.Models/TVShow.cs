namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TVShow
    {

        public string Title { get; set; }

        public string ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public int ReviewsCount { get; set; }

        public ICollection<CastMember> Creators { get; set; }

        public ICollection<CastMember> Stars { get; set; } = new HashSet<CastMember>();

        public ICollection<int> Seasons { get; set; } = new HashSet<int>();
    }
}
