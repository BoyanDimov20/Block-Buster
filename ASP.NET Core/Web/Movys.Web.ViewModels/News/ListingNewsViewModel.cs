namespace Movys.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListingNewsViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public NewsSearchInputModel SearchInputModel { get; set; } = new NewsSearchInputModel();
    }
}
