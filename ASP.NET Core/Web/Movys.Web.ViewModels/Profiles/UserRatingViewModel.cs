namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserRatingViewModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int ReviewsCount { get; set; }

        public ChangeAvatarViewModel AvatarViewModel { get; set; } = new ChangeAvatarViewModel();
    }
}
