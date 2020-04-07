namespace Movys.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class CastMemberViewModel : IMapFrom<CastMember>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CastMemberMovieViewModel> Movies { get; set; }
    }
}
