namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Newsletter
    {
        public Newsletter()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
