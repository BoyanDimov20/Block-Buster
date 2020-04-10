namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.News;

    public class NewsController : BaseController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Listing()
        {
            ListingNewsViewModel viewModel = new ListingNewsViewModel
            {
                News = this.newsService.GetAll<NewsViewModel>().ToList(),
            };

            return this.View(viewModel);
        }
    }
}
