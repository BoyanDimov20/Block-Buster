namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Common.Models;

    public class MoviesUser
    {
        public virtual Movie Movie { get; set; }

        public string MovieId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
