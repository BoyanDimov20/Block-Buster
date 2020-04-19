namespace Movys.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public NewsCategory Category { get; set; }

        public string ShortDescription => string.Join(string.Empty, this.Content.Take(170));

        public IEnumerable<TagsViewModel> Tags { get; set; }
    }
}
