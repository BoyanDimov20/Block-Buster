namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Tag
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<NewsTags> News { get; set; } = new HashSet<NewsTags>();
    }
}
