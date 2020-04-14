namespace Movys.Web.ViewModels.Celebs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListingCelebsViewModel
    {
        public IEnumerable<SingleCelebViewModel> CastMembers { get; set; }

        public SearchInputModel SearchInputModel { get; set; } = new SearchInputModel();

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int CelebsCount { get; set; }
    }
}
