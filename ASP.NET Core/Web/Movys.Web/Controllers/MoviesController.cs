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
        private readonly IProfilePicturesService profilePicturesService;

        public MoviesController(IMoviesService moviesService, IGenresMovieService genresMovieService, IReviewsService reviewsService, IRepository<MoviesUser> favouriteMovieRepository, IProfilePicturesService profilePicturesService)
        {
            this.moviesService = moviesService;
            this.genresMovieService = genresMovieService;
            this.reviewsService = reviewsService;
            this.favouriteMovieRepository = favouriteMovieRepository;
            this.profilePicturesService = profilePicturesService;
        }

        public IActionResult ById(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            SingleMovieViewModel viewModel = this.moviesService.GetAll<SingleMovieViewModel>().First(x => x.Id == id);

            foreach (var review in viewModel.Reviews)
            {
                review.UserAvatar = this.profilePicturesService.GetAvatarByUserId(review.UserId);
            }

            if (this.User.Identity.IsAuthenticated)
            {
                viewModel.CurrentUserAvatar = this.profilePicturesService.GetAvatarByUserId(userId);
            }

            viewModel.RelatedMovies = this.moviesService.GetAll<MovieViewModel>().Where(x => x.Genres.Any(y => viewModel.Genres.Any(z => z.GenreName == y.GenreName)) && x.Id != id);
            viewModel.IsAddedToFavorite = this.favouriteMovieRepository.All().Any(x => x.UserId == userId && id == x.MovieId);
            return this.View(viewModel);
        }

        public IActionResult Listing(string crit, int pageNumber = 1, int pageSize = 5)
        {
            this.ViewData["Crit"] = crit;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.moviesService.GetAll<SingleMovieViewModel>().Count();

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().ToList(),
                SearchFormInputModel = new SearchFormInputModel()
                {
                    Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList(),
                },
                CurrentPage = pageNumber,
                MoviesPerPage = pageSize,
                MoviesCountFound = recordsCount,
            };

            if (recordsCount % 5 == 0)
            {
                viewModel.PagesCount = recordsCount / 5;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 5) + 1;
            }

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
            else if (crit == "reviews")
            {
                this.ViewData["Title"] = "MOST REVIEWED MOVIES";
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Reviews.Count()).ToList();
            }

            // Pagination
            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();
            return this.View(viewModel);
        }

        public IActionResult ListingGrid(string crit, int pageNumber = 1)
        {
            this.ViewData["Crit"] = crit;
            int pageSize = 12;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.moviesService.GetAll<SingleMovieViewModel>().Count();

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().ToList(),
                SearchFormInputModel = new SearchFormInputModel()
                {
                    Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList(),
                },
                CurrentPage = pageNumber,
                MoviesPerPage = pageSize,
                MoviesCountFound = recordsCount,
            };

            if (recordsCount % 12 == 0)
            {
                viewModel.PagesCount = recordsCount / 12;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 12) + 1;
            }

            // Sorting
            if (crit == "popularity")
            {
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Reviews.Count()).ToList();
            }
            else if (crit == "rating")
            {
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Rating).ToList();
            }
            else if (crit == "reviews")
            {
                viewModel.Movies = viewModel.Movies.OrderByDescending(x => x.Reviews.Count()).ToList();
            }

            // Pagination
            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewFormInputModel inputModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.reviewsService.AddReview(inputModel.Title, inputModel.Content, inputModel.Rating, inputModel.MovieId, userId);
            var avatar = this.profilePicturesService.GetAvatarByUserId(userId);

            var obj = new
            {
                Avatar = avatar,
                CreatedOn = DateTime.UtcNow,
            };

            return this.Json(obj);
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
            this.ViewData["Result"] = result ?? string.Empty;
            this.ViewData["Genre"] = genre ?? string.Empty;
            this.ViewData["Rating"] = rating;

            int pageSize = 5;
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            if (result == null)
            {
                result = string.Empty;
            }

            string normalizedResult = result.ToLower();

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().Where(x => x.Title.ToLower().Contains(result) || x.Description.ToLower().Contains(result)).ToList(),
                CurrentPage = pageNumber,
                MoviesPerPage = pageSize,
            };

            if (genre != null)
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Genres.Any(x => x.GenreId == genre)).ToList();
            }

            if (rating != 0)
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Rating >= rating).ToList();
            }

            int recordsCount = viewModel.Movies.Count();
            viewModel.MoviesCountFound = recordsCount;
            if (recordsCount % 5 == 0)
            {
                viewModel.PagesCount = recordsCount / 5;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 5) + 1;
            }

            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();
            viewModel.SearchFormInputModel.Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList();
            return this.View(viewModel);
        }

        [Route("/Movies/SearchGrid")]
        public IActionResult ResultGrid(string result, string genre, double rating, int pageNumber = 1)
        {
            this.ViewData["Result"] = result ?? string.Empty;
            this.ViewData["Genre"] = genre ?? string.Empty;
            this.ViewData["Rating"] = rating;

            int pageSize = 12;
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            if (result == null)
            {
                result = string.Empty;
            }

            string normalizedResult = result.ToLower();

            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().Where(x => x.Title.ToLower().Contains(result) || x.Description.ToLower().Contains(result)).ToList(),
                CurrentPage = pageNumber,
                MoviesPerPage = pageSize,
            };

            if (genre != null)
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Genres.Any(x => x.GenreId == genre)).ToList();
            }

            if (rating != 0)
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Rating >= rating).ToList();
            }

            int recordsCount = viewModel.Movies.Count();
            viewModel.MoviesCountFound = recordsCount;
            if (recordsCount % 12 == 0)
            {
                viewModel.PagesCount = recordsCount / 12;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 12) + 1;
            }

            viewModel.Movies = viewModel.Movies.Skip(excludeRecords).Take(pageSize).ToList();
            viewModel.SearchFormInputModel.Genres = this.genresMovieService.GetAll<GenreViewModel>().Distinct(new GenreComparer()).ToList();
            return this.View(viewModel);
        }
    }
}
