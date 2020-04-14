namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.News;

    public class NewsController : BaseController
    {
        private readonly INewsService newsService;
        private readonly ICommentsService commentsService;

        public NewsController(INewsService newsService, ICommentsService commentsService)
        {
            this.newsService = newsService;
            this.commentsService = commentsService;
        }

        public IActionResult Listing(int pageNumber = 1, int pageSize = 5)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.newsService.GetAll<NewsViewModel>().Count();

            ListingNewsViewModel viewModel = new ListingNewsViewModel
            {
                News = this.newsService.GetAll<NewsViewModel>().OrderByDescending(x => x.CreatedOn).ToList(),
                CurrentPage = pageNumber,
            };

            if (recordsCount % 5 == 0 || recordsCount < 5)
            {
                viewModel.PagesCount = recordsCount / 5;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 5) + 1;
            }

            viewModel.News = viewModel.News.Skip(excludeRecords).Take(pageSize).ToList();

            return this.View(viewModel);
        }

        public IActionResult ById(string id)
        {
            SingleNewsViewModel viewModel = this.newsService.GetAll<SingleNewsViewModel>().FirstOrDefault(x => x.Id == id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CreateCommentInputModel inputModel, string newsId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (this.ModelState.IsValid)
            {
                await this.commentsService.CreateCommentAsync(inputModel.Content, userId, newsId);
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Your comment must contain at least 150 characters.");
            }

            return this.Redirect($"/News/ById?id={newsId}");
        }
    }
}
