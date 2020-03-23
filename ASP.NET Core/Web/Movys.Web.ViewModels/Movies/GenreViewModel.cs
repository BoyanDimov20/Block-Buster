namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class GenreViewModel : IMapFrom<GenresMovie>
    {
        public string GenreId { get; set; }

        public string GenreName { get; set; }
    }
}
