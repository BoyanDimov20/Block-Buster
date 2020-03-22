namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Movys.Data.Common.Models;

    public class TVShow : BaseDeletableModel<string>
    {
        [Required]
        public string Title { get; set; }

        public string ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public int ReviewsCount { get; set; }

        public ICollection<TVShowsCastMember> CastMembers { get; set; } = new HashSet<TVShowsCastMember>();
    }
}
