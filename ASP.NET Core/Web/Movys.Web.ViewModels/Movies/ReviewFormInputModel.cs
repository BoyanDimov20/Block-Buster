namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReviewFormInputModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public double Rating { get; set; }

        public string MovieId { get; set; }

    }
}
