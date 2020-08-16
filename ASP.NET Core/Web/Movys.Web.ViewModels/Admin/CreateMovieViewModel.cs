namespace Movys.Web.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateMovieViewModel
    {
        public IEnumerable<GenresViewModel> Genres { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string Country { get; set; }

        public int Runtime { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        [Required]
        public IEnumerable<string> GenreId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
