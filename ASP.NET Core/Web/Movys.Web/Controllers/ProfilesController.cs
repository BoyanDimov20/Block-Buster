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
    using Movys.Web.ViewModels.Profiles;

    [Authorize]
    public class ProfilesController : BaseController
    {
        private readonly IReviewsService reviewsService;

        public ProfilesController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        public IActionResult UserProfile()
        {
            return this.View();
        }

        public IActionResult UserRating()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<ReviewViewModel> viewModel = this.reviewsService.GetAll<ReviewViewModel>().Where(x => x.UserId == userId);
            return this.View(viewModel);
        }

        public IActionResult UserFavouriteList()
        {
            return this.View();
        }
    }
}
