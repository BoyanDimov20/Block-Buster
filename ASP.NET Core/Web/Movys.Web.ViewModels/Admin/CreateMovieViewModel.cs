namespace Movys.Web.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateMovieViewModel
    {
        public IEnumerable<GenresViewModel> Genres { get; set; }
    }
}
