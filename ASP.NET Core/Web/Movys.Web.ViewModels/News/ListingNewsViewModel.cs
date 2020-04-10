namespace Movys.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListingNewsViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }
    }
}
