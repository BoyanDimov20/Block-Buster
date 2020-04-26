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
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
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

        public async Task<IActionResult> UserProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            ProfileInfoViewModel viewModel = new ProfileInfoViewModel
            {
                AvatarViewModel = new ChangeAvatarViewModel
                {
                    CurrentAvatar = await this.profilePicturesService.GetAvatarByUserId(userId),
                },
                AdditionInfoViewModel = new AdditionInfoViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    City = user.City,
                    Country = user.Country,
                },
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAdditionalInfo([FromBody] AdditionInfoInputModel additionInfoInput)
        {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            user.FirstName = additionInfoInput.FirstName;
            user.LastName = additionInfoInput.LastName;
            user.Country = additionInfoInput.Country;
            user.City = additionInfoInput.City;
            await this.userManager.UpdateAsync(user);
            return this.Redirect("/Profiles/UserProfile");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordInputModel inputModel)
        {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            if (this.ModelState.IsValid)
            {
                var result = await this.userManager.ChangePasswordAsync(user, inputModel.OldPassword, inputModel.NewPassword);
                if (result.Succeeded)
                {
                    return this.Ok();
                }

                foreach (var item in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, item.Description);
                }
            }

            return this.ValidationProblem();
        }

        public async Task<IActionResult> UserRating(int pageNumber = 1, int pageSize = 5)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = (await this.reviewsService.GetAll<ReviewViewModel>()).Count(x => x.UserId == userId);

            UserRatingViewModel viewModel = new UserRatingViewModel
            {
                Reviews = (await this.reviewsService.GetAll<ReviewViewModel>()).Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedOn),
                CurrentPage = pageNumber,
                ReviewsCount = recordsCount,
                AvatarViewModel = new ChangeAvatarViewModel
                {
                    CurrentAvatar = await this.profilePicturesService.GetAvatarByUserId(userId),
                },
            };

            if (recordsCount % 5 == 0)
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

        public async Task<IActionResult> UserFavouriteList(int pageNumber = 1, int pageSize = 5)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            ListingFavoriteMoviesViewModel viewModel = new ListingFavoriteMoviesViewModel
            {
                Movies = await this.favoriteMoviesService.GetAllByUserId<FavoriteMovieViewModel>(userId),
                CurrentPage = pageNumber,
                AvatarViewModel = new ChangeAvatarViewModel
                {
                    CurrentAvatar = await this.profilePicturesService.GetAvatarByUserId(userId),
                },
            };

            viewModel.MoviesCount = viewModel.Movies.Count();
            int recordsCount = viewModel.MoviesCount;

            if (recordsCount % 5 == 0)
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
