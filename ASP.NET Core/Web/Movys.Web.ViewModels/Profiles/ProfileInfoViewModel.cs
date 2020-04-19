namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class ProfileInfoViewModel
    {
        public ChangeAvatarViewModel AvatarViewModel { get; set; }

        public AdditionInfoViewModel AdditionInfoViewModel { get; set; }

        public AdditionInfoInputModel AdditionInfoInput { get; set; }

        public ChangePasswordInputModel ChangePasswordInput { get; set; }
    }
}
