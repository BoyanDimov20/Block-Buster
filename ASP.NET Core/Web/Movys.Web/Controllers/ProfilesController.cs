namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Web.Helpers;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Profiles;

    [Authorize]
    public class ProfilesController : BaseController
    {
        private readonly IReviewsService reviewsService;
        private readonly IFavoriteMoviesService favoriteMoviesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfilePicturesService profilePicturesService;

        public ProfilesController(IReviewsService reviewsService, IFavoriteMoviesService favoriteMoviesService, UserManager<ApplicationUser> userManager, IProfilePicturesService profilePicturesService)
        {
            this.reviewsService = reviewsService;
            this.favoriteMoviesService = favoriteMoviesService;
            this.userManager = userManager;
            this.profilePicturesService = profilePicturesService;
        }

        public IActionResult UserProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ProfileInfoViewModel viewModel = new ProfileInfoViewModel
            {
                AvatarViewModel = new ChangeAvatarViewModel
                {
                    CurrentAvatar = this.profilePicturesService.GetAvatarByUserId(userId),
                },
            };

            return this.View(viewModel);
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
                AvatarViewModel = new ChangeAvatarViewModel
                {
                    CurrentAvatar = this.profilePicturesService.GetAvatarByUserId(userId),
                },
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
                AvatarViewModel = new ChangeAvatarViewModel
                {
                    CurrentAvatar = this.profilePicturesService.GetAvatarByUserId(userId),
                },
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

        [HttpPost]
        public async Task<IActionResult> Upload(ChangeAvatarViewModel file)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await this.profilePicturesService.AddPictureAsync(file.Avatar, userId);

            if (!result)
            {
                this.ModelState.AddModelError("File", "The file is too large.");
            }

            return this.Redirect("/Profiles/UserProfile");
        }
    }
}
