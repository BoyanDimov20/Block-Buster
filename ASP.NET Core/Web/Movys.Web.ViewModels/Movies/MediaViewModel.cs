namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class MediaViewModel : IMapFrom<Media>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string HoverImageUrl { get; set; }

        public string Time { get; set; }

        public MediaType MediaType { get; set; }
    }
}
