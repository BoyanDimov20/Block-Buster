namespace Movys.Web.ViewModels.Movies
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class GenreComparer : IEqualityComparer<GenreViewModel>
    {
        public bool Equals(GenreViewModel x, GenreViewModel y)
        {
            return x.GenreName == y.GenreName;
        }

        public int GetHashCode(GenreViewModel obj)
        {
            return obj.GenreName.GetHashCode();
        }
    }
}
