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

        public IActionResult UserRating()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<ReviewViewModel> viewModel = this.reviewsService.GetAll<ReviewViewModel>().Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedOn);
            return this.View(viewModel);
        }

        public IActionResult UserFavouriteList()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ListingFavoriteMoviesViewModel viewModel = new ListingFavoriteMoviesViewModel
            {
                Movies = this.favoriteMoviesService.GetAllByUserId<FavoriteMovieViewModel>(userId),
            };

            return this.View(viewModel);
        }
    }
}
