namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class ChangeAvatarViewModel
    {
        public IFormFile Avatar { get; set; }

        public string CurrentAvatar { get; set; }
    }
}
