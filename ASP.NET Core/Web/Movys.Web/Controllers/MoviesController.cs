namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Movys.Services.Data;
    using Movys.Web.Infrastructure;
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

        public IActionResult ListingMostPopular(int pageNumber = 1)
        {
            this.ViewData["CurrentPage"] = pageNumber;
            int pageSize = 5;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.moviesService.GetAll<SingleMovieViewModel>().Count();

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
                Movies = this.moviesService.GetAll<SingleMovieViewModel>().OrderByDescending(x => x.Reviews.Count()).Skip(excludeRecords).Take(pageSize).ToList(),
            };

            return this.View(viewModel);
        }
    }
}
