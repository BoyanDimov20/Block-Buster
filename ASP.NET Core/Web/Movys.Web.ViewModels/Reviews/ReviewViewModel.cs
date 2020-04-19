namespace Movys.Web.ViewModels.Reviews
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class ReviewViewModel : IMapFrom<Review>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public string UserAvatar { get; set; }
    }
}
