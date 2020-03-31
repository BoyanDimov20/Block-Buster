namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : BaseController
    {
        public IActionResult UserProfile()
        {
            return this.View();
        }

        public IActionResult UserRating()
        {
            return this.View();
        }
    }
}
