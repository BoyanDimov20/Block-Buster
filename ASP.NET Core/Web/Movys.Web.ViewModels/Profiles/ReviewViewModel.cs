namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class ReviewViewModel : IMapFrom<Review>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public string MovieId { get; set; }

        public string MovieImageUrl { get; set; }

        public string MovieTitle { get; set; }

        public string MovieReleaseYear { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }
    }
}
