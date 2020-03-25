namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Media
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Url { get; set; }

        public string CastMemberId { get; set; }

        public virtual CastMember CastMember { get; set; }
    }
}
