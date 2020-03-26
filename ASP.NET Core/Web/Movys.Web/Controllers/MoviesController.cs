namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Movies;

    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IActionResult ById(string id)
        {
            SingleMovieViewModel viewModel = this.moviesService.GetAll<SingleMovieViewModel>().First(x => x.Id == id);
            return this.View(viewModel);
        }

        public IActionResult ListingMostPopular()
        {
            ListingMoviesViewModel viewModel = new ListingMoviesViewModel
            {
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().OrderByDescending(x => x.Reviews.Count()).ToList(),
            };

            return this.View(viewModel);
        }
    }
}
