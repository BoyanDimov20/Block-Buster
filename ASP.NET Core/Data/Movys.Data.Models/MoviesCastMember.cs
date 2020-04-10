namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Movys.Data.Common.Models;

    public class MoviesCastMember
    {
        public virtual Movie Movie { get; set; }

        public string MovieId { get; set; }

        public virtual CastMember CastMember { get; set; }

        public string CastMemberId { get; set; }

        [Required]
        public RoleType RoleType { get; set; }

        public string RoleName { get; set; }
    }
}
