namespace Movys.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class CastMemberMovieViewModel : IMapFrom<MoviesCastMember>
    {
        public RoleType RoleType { get; set; }
    }
}
