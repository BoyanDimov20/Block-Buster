namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Internal;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Movies;

    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;
        private readonly IGenresMovieService genresMovieService;
        private readonly IReviewsService reviewsService;
        private readonly IRepository<MoviesUser> favouriteMovieRepository;

        public MoviesController(IMoviesService moviesService, IGenresMovieService genresMovieService, IReviewsService reviewsService, IRepository<MoviesUser> favouriteMovieRepository)
        {
            this.moviesService = moviesService;
            this.genresMovieService = genresMovieService;
            this.reviewsService = reviewsService;
            this.favouriteMovieRepository = favouriteMovieRepository;
        }

        public IActionResult ById(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            SingleMovieViewModel viewModel = this.moviesService.GetAll<SingleMovieViewModel>().First(x => x.Id == id);
            viewModel.RelatedMovies = this.moviesService.GetAll<MovieViewModel>().Where(x => x.Genres.Any(y => viewModel.Genres.Any(z => z.GenreName == y.GenreName)) && x.Id != id);
            viewModel.IsAddedToFavorite = this.favouriteMovieRepository.All().Any(x => x.UserId == userId && id == x.MovieId);
            return this.View(viewModel);
        }

        public IActionResult Listing(string crit, int pageNumber = 1)
        {
            this.ViewData["Crit"] = crit;
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
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().ToList(),
                SearchFormInputModel = new SearchFormInputModel()
                {
                    Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList(),
                },
            };

            // Sorting
            if (crit == "popularity")
            {
                this.ViewData["Title"] = "MOST POPULAR MOVIES";
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Reviews.Count()).ToList();
            }
            else if (crit == "rating")
            {
                this.ViewData["Title"] = "TOP RATED MOVIES";
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Rating).ToList();
            }

            // Pagination
            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();
            return this.View(viewModel);
        }

        public IActionResult ListingGrid(string crit, int pageNumber = 1)
        {
            this.ViewData["Crit"] = crit;
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
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().ToList(),
                SearchFormInputModel = new SearchFormInputModel()
                {
                    Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList(),
                },
            };

            // Sorting
            if (crit == "popularity")
            {
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Reviews.Count()).ToList();
            }
            else if (crit == "rating")
            {
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Rating).ToList();
            }

            // Pagination
            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ReviewForm(ReviewFormInputModel inputModel, string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.reviewsService.AddReview(inputModel.Title, inputModel.Content, inputModel.Rating, id, userId);

            return this.Redirect($"/Movies/ById?id={id}");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavourite(string movieId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var vote = this.favouriteMovieRepository.All().FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);

            if (vote != null)
            {
                this.favouriteMovieRepository.Delete(vote);
            }
            else
            {
                vote = new MoviesUser
                {
                    MovieId = movieId,
                    UserId = userId,
                };
                await this.favouriteMovieRepository.AddAsync(vote);
            }

            await this.favouriteMovieRepository.SaveChangesAsync();

            return this.Ok();
        }

        [Route("/Movies/Search")]
        public IActionResult Result(string result, string genre, double rating, int pageNumber = 1)
        {
            this.ViewData["SearchString"] = result;
            this.ViewData["CurrentPage"] = pageNumber;
            int pageSize = 5;
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            if (result == null)
            {
                result = string.Empty;
            }

            string normalizedResult = result.ToLower();
            int recordsCount = this.moviesService.GetAll<SingleMovieViewModel>().Where(x => x.Title.ToLower().Contains(normalizedResult) || x.Description.ToLower().Contains(normalizedResult)).Count();
            this.ViewData["RecordsCount"] = recordsCount;
            if (recordsCount % 5 == 0)
            {
                this.ViewData["PagesCount"] = recordsCount / 5;
            }
            else
            {
                this.ViewData["PagesCount"] = (recordsCount / 5) + 1;
            }

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().Where(x => x.Title.ToLower().Contains(result) || x.Description.ToLower().Contains(result)).Skip(excludeRecords).Take(pageSize).ToList(),
            };

            if (genre != null)
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Genres.Any(x => x.GenreId == genre)).ToList();
            }

            if (rating != 0)
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Rating >= rating).ToList();
            }

            viewModel.SearchFormInputModel.Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList();
            return this.View(viewModel);
        }
    }
}
