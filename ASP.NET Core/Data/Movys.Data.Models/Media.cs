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

        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
