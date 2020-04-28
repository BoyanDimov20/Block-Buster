namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Movys.Data.Common.Models;

    public class Comment : BaseDeletableModel<string>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
