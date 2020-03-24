namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
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
    }
}
