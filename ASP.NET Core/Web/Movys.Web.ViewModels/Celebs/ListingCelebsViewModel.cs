namespace Movys.Web.ViewModels.Celebs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListingCelebsViewModel
    {
        public IEnumerable<SingleCelebViewModel> CastMembers { get; set; }

        public int CelebsCount => this.CastMembers.Count();
    }
}
