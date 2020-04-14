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

        public IActionResult Listing()
        {
            ListingNewsViewModel viewModel = new ListingNewsViewModel
            {
                News = this.newsService.GetAll<NewsViewModel>().OrderByDescending(x => x.CreatedOn).ToList(),
            };

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
