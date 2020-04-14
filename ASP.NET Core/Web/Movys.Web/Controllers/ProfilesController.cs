namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Profiles;

    [Authorize]
    public class ProfilesController : BaseController
    {
        private readonly IReviewsService reviewsService;
        private readonly IFavoriteMoviesService favoriteMoviesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(IReviewsService reviewsService, IFavoriteMoviesService favoriteMoviesService, UserManager<ApplicationUser> userManager)
        {
            this.reviewsService = reviewsService;
            this.favoriteMoviesService = favoriteMoviesService;
            this.userManager = userManager;
        }

        public IActionResult UserProfile()
        {
            //var userPic = this.userManager.FindByNameAsync(this.User.Identity.Name).Result.
            return this.View();
        }

        public IActionResult UserRating(int pageNumber = 1, int pageSize = 5)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.reviewsService.GetAll<ReviewViewModel>().Count(x => x.UserId == userId);

            UserRatingViewModel viewModel = new UserRatingViewModel
            {
                Reviews = this.reviewsService.GetAll<ReviewViewModel>().Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedOn),
                CurrentPage = pageNumber,
                ReviewsCount = recordsCount,
            };

            if (recordsCount % 5 == 0 || recordsCount < 5)
            {
                viewModel.PagesCount = recordsCount / 5;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 5) + 1;
            }

            viewModel.Reviews = viewModel.Reviews.Skip(excludeRecords).Take(pageSize).ToList();
            return this.View(viewModel);
        }

        public IActionResult UserFavouriteList(int pageNumber = 1, int pageSize = 5)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.reviewsService.GetAll<ReviewViewModel>().Count();

            ListingFavoriteMoviesViewModel viewModel = new ListingFavoriteMoviesViewModel
            {
                Movies = this.favoriteMoviesService.GetAllByUserId<FavoriteMovieViewModel>(userId),
                CurrentPage = pageNumber,
                MoviesCount = recordsCount,
            };

            if (recordsCount % 5 == 0 || recordsCount < 5)
            {
                viewModel.PagesCount = recordsCount / 5;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 5) + 1;
            }

            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();

            return this.View(viewModel);
        }
    }
}
