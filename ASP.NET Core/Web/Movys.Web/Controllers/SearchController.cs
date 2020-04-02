namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Movies;

    public class SearchController : BaseController
    {
        private readonly IMoviesService moviesService;

        public SearchController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [Route("/Search")]
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

            return this.View(viewModel);
        }
    }
}
