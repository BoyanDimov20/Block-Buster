namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Common.Models;

    public class Comment : BaseDeletableModel<string>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
