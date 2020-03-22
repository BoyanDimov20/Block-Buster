namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class TVShowsCastMember
    {
        public virtual TVShow TVShow { get; set; }

        public string TVShowId { get; set; }

        public virtual CastMember CastMember { get; set; }

        public string CastMemberId { get; set; }

        [Required]
        public RoleType RoleType { get; set; }

        public string RoleName { get; set; }
    }
}
