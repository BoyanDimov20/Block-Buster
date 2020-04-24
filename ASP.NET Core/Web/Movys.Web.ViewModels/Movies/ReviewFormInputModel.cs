namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ReviewFormInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Rating { get; set; }

        [Range(1, 10)]
        public double RatingAsNumber => double.Parse(this.Rating);

        public string MovieId { get; set; }

    }
}
