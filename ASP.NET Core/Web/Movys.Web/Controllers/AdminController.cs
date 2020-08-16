namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Movys.Common;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Services.Mapping;
    using Movys.Web.ViewModels.Admin;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        private readonly IRepository<Genre> genresRepository;
        private readonly IMoviesService moviesService;

        public AdminController(IRepository<Genre> genresRepository, IMoviesService moviesService)
        {
            this.genresRepository = genresRepository;
            this.moviesService = moviesService;
        }

        public async Task<IActionResult> AddMovie()
        {
            var viewModel = new CreateMovieViewModel
            {
                Genres = await this.genresRepository.All().To<GenresViewModel>().ToListAsync(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(CreateMovieViewModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var movieId = await this.moviesService.CreateMovie(inputModel.Title, inputModel.ReleaseDate, inputModel.ImageUrl, inputModel.GenreId, inputModel.Description, inputModel.Country, inputModel.Runtime, inputModel.TrailerUrl);
                return this.Redirect($"/Movies/ById/{movieId}");
            }

            return this.View();
        }
    }
}
