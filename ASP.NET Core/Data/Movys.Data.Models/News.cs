namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Common.Models;

    public class News : BaseDeletableModel<string>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public NewsCategory Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public virtual ICollection<NewsTags> Tags { get; set; } = new HashSet<NewsTags>();
    }
}
