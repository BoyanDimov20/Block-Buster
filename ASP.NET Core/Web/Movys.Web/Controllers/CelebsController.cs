namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Celebs;

    public class CelebsController : BaseController
    {
        private readonly ICelebsService celebsService;

        public CelebsController(ICelebsService celebsService)
        {
            this.celebsService = celebsService;
        }

        public IActionResult ById(string id)
        {
            SingleCelebViewModel viewModel = this.celebsService.GetAll<SingleCelebViewModel>().First(x => x.Id == id);
            return this.View(viewModel);
        }

        public IActionResult ListingMostPopular(int pageNumber = 1, int pageSize = 5)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = this.celebsService.GetAll<SingleCelebViewModel>().Count();

            ListingCelebsViewModel viewModel = new ListingCelebsViewModel
            {
                CastMembers = this.celebsService.GetAll<SingleCelebViewModel>().ToList(),
                CurrentPage = pageNumber,
                CelebsCount = recordsCount,
            };

            if (recordsCount % 5 == 0 || recordsCount < 5)
            {
                viewModel.PagesCount = recordsCount / 5;
            }
            else
            {
                viewModel.PagesCount = (recordsCount / 5) + 1;
            }

            viewModel.CastMembers = viewModel.CastMembers.Skip(excludeRecords).Take(pageSize).ToList();

            return this.View(viewModel);
        }

        [Route("/Celebs/Search")]
        public IActionResult Result(string result, string category)
        {
            ListingCelebsViewModel viewModel = new ListingCelebsViewModel()
            {
                CastMembers = this.celebsService.GetAll<SingleCelebViewModel>(),
            };

            if (result != null)
            {
                viewModel.CastMembers = viewModel.CastMembers.Where(x => x.Name.ToLower().Contains(result.ToLower()));
            }

            if (category != "-1")
            {
                RoleType role = (RoleType)Enum.Parse(typeof(RoleType), category);
                viewModel.CastMembers = viewModel.CastMembers.Where(x => x.Movies.Any(y => y.RoleType == role.ToString()));
            }

            return this.View(viewModel);
        }
    }
}
