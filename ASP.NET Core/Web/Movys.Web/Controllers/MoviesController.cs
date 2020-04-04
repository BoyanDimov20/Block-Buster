namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Movies;
    using Movys.Web.ViewModels.Reviews;

    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;
        private readonly IGenresMovieService genresMovieService;
        private readonly IReviewsService reviewsService;

        public MoviesController(IMoviesService moviesService, IGenresMovieService genresMovieService, IReviewsService reviewsService)
        {
            this.moviesService = moviesService;
            this.genresMovieService = genresMovieService;
            this.reviewsService = reviewsService;
        }

        public IActionResult ById(string id)
        {
            SingleMovieViewModel viewModel = this.moviesService.GetAll<SingleMovieViewModel>().First(x => x.Id == id);
            return this.View(viewModel);
        }

        public IActionResult ListingMostPopular(int pageNumber = 1)
        {
            this.ViewData["CurrentPage"] = pageNumber;
            int pageSize = 5;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.moviesService.GetAll<SingleMovieViewModel>().Count();
            this.ViewData["RecordsCount"] = recordsCount;

            if (recordsCount % 5 == 0 || recordsCount < 5)
            {
                this.ViewData["PagesCount"] = recordsCount / 5;
            }
            else
            {
                this.ViewData["PagesCount"] = (recordsCount / 5) + 1;
            }

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().OrderByDescending(x => x.Reviews.Count()).Skip(excludeRecords).Take(pageSize).ToList(),
                Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct().ToList(),
                Reviews = this.reviewsService.GetAll<ReviewViewModel>().ToList(),
            };

            return this.View(viewModel);
        }

        public IActionResult ListingMostPopularGrid(int pageNumber = 1)
        {
            this.ViewData["CurrentPage"] = pageNumber;
            int pageSize = 20;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.moviesService.GetAll<SingleMovieViewModel>().Count();
            this.ViewData["RecordsCount"] = recordsCount;

            if (recordsCount % 20 == 0 || recordsCount < 20)
            {
                this.ViewData["PagesCount"] = recordsCount / 5;
            }
            else
            {
                this.ViewData["PagesCount"] = (recordsCount / 5) + 1;
            }

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().OrderByDescending(x => x.Reviews.Count()).Skip(excludeRecords).Take(pageSize).ToList(),
                Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct().ToList(),
                Reviews = this.reviewsService.GetAll<ReviewViewModel>().ToList(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ReviewForm(ReviewFormInputModel inputModel, string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.reviewsService.AddReview(inputModel.Title, inputModel.Content, inputModel.Rating, id, userId);

            return this.Redirect($"/Movies/ById?id={id}");
        }
    }
}
