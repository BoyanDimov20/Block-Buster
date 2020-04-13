namespace Movys.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class SingleNewsViewModel : IMapFrom<News>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public CreateCommentInputModel CommentInputModel { get; set; } = new CreateCommentInputModel();
    }
}
