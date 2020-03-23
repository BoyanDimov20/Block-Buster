namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class CastMemberViewModel : IMapFrom<MoviesCastMember>
    {
        public string CastMemberId { get; set; }

        public string CastMemberName { get; set; }

        public string CastMemberImageUrl { get; set; }

        public string RoleName { get; set; }

        public RoleType RoleType { get; set; }
    }
}
