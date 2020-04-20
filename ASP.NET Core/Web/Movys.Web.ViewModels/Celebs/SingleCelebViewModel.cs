namespace Movys.Web.ViewModels.Celebs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class SingleCelebViewModel : IMapFrom<CastMember>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string ShortBiography => string.Join(string.Empty, this.FullBiography.Take(200));

        public string FullBiography { get; set; }

        public string BornInfo { get; set; }

        public string CountryBornIn { get; set; }

        public int Height { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string GoogleUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}
