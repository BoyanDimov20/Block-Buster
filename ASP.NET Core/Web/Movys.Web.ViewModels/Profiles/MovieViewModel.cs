namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class MovieViewModel : IMapFrom<MoviesCastMember>
    {
        public string CastMemberId { get; set; }

        public string CastMemberName { get; set; }

        public RoleType RoleType { get; set; }
    }
}
