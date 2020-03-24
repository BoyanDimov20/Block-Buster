namespace Movys.Web.ViewModels.Celebs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class MovieViewModel : IMapFrom<MoviesCastMember>
    {
        public string RoleName { get; set; }

        public string MovieId { get; set; }

        public string MovieTitle { get; set; }

        public string MovieReleaseYear { get; set; }

        public string MovieImageUrl { get; set; }
    }
}
