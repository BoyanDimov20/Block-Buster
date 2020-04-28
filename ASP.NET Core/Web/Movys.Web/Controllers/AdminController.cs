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
    using Movys.Services.Mapping;
    using Movys.Web.ViewModels.Admin;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        private readonly IRepository<Genre> genresRepository;

        public AdminController(IRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
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
        public async Task<IActionResult> AddMovie(string hello)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
