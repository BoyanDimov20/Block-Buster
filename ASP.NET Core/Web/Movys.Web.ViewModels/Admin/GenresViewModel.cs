namespace Movys.Web.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class GenresViewModel : IMapFrom<Genre>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
