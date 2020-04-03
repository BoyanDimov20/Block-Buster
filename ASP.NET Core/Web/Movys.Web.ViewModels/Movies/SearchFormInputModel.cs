namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchFormInputModel
    {
        public string Result { get; set; }

        public string Genre { get; set; }

        public double Rating { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
