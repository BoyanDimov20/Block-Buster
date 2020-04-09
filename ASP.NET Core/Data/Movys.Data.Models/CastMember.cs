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

        public string FullBiography { get; set; }

        public string BornInfo { get; set; }

        public string CountryBornIn { get; set; }

        public int Height { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string GoogleUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public virtual ICollection<MoviesCastMember> Movies { get; set; } = new HashSet<MoviesCastMember>();
    }
}
