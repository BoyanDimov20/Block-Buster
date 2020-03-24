namespace Movys.Web.ViewModels.Celebs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class SingleCelebViewModel : IMapFrom<CastMember>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string BornInfo { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}
