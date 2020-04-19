namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NewsTags
    {
        public string NewsId { get; set; }

        public virtual News News { get; set; }

        public string TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
