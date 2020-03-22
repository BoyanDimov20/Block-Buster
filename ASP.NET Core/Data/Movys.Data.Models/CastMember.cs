namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Movys.Data.Common.Models;

    public class CastMember : BaseDeletableModel<string>
    {
        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string BornInfo { get; set; }

        public ICollection<MoviesCastMember> Movies { get; set; }

        public ICollection<TVShowsCastMember> TVShows { get; set; }
    }
}
