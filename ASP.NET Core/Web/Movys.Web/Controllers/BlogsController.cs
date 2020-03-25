namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : BaseController
    {
        public IActionResult Listing()
        {
            return this.View();
        }
    }
}
