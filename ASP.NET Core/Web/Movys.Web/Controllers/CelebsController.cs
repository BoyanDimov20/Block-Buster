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

        public async Task<IActionResult> ById(string id)
        {
            SingleCelebViewModel viewModel = (await this.celebsService.GetAll<SingleCelebViewModel>()).FirstOrDefault(x => x.Id == id);
            if (viewModel == null)
            {
                return this.StatusCode(404);
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> ListingMostPopular(int pageNumber = 1, int pageSize = 5)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int recordsCount = (await this.celebsService.GetAll<SingleCelebViewModel>()).Count();

            ListingCelebsViewModel viewModel = new ListingCelebsViewModel
            {
                CastMembers = await this.celebsService.GetAll<SingleCelebViewModel>(),
                CurrentPage = pageNumber,
                CelebsCount = recordsCount,
            };

            if (recordsCount % 5 == 0)
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
        public async Task<IActionResult> Result(string result, string category, int pageNumber = 1, int pageSize = 5)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            this.ViewData["Result"] = result;
            this.ViewData["Category"] = category;

            ListingCelebsViewModel viewModel = new ListingCelebsViewModel()
            {
                CastMembers = await this.celebsService.GetAll<SingleCelebViewModel>(),
                CurrentPage = pageNumber,
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

            int recordsCount = viewModel.CastMembers.Count();
            viewModel.CelebsCount = recordsCount;

            if (recordsCount % 5 == 0)
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
    }
}
