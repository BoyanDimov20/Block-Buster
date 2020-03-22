namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Movys.Data.Common.Models;

    public class Genre
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GenresMovie> Movies { get; set; } = new HashSet<GenresMovie>();

        public virtual ICollection<GenresTVShow> TVShows { get; set; } = new HashSet<GenresTVShow>();
    }
}
