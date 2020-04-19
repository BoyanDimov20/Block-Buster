namespace Movys.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public string UserId { get; set; }

        public string Avatar { get; set; }

    }
}
