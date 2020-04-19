namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.News;

    public class NewsController : BaseController
    {
        private readonly INewsService newsService;
        private readonly ICommentsService commentsService;
        private readonly IProfilePicturesService profilePicturesService;

        public NewsController(INewsService newsService, ICommentsService commentsService, IProfilePicturesService profilePicturesService)
        {
            this.newsService = newsService;
            this.commentsService = commentsService;
            this.profilePicturesService = profilePicturesService;
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

            if (recordsCount % 5 == 0)
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
            foreach (var comment in viewModel.Comments)
            {
                comment.Avatar = this.profilePicturesService.GetAvatarByUserId(comment.UserId);
            }

            return this.View(viewModel);
        }

        [Route("/News/Search")]
        public IActionResult Result(string result, string category, int pageNumber = 1, int pageSize = 5)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            if (result == null)
            {
                result = string.Empty;
            }

            ListingNewsViewModel viewModel = new ListingNewsViewModel
            {
                News = this.newsService.GetAll<NewsViewModel>().Where(x => x.Title.ToLower().Contains(result.ToLower()) || x.Content.ToLower().Contains(result.ToLower())).OrderByDescending(x => x.CreatedOn).ToList(),
                CurrentPage = pageNumber,
            };

            if (category != "0")
            {
                NewsCategory newsCategory = (NewsCategory)Enum.Parse(typeof(NewsCategory), category);
                viewModel.News = viewModel.News.Where(x => x.Category == newsCategory);
            }

            int recordsCount = viewModel.News.Count();

            if (recordsCount % 5 == 0)
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
