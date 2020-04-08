namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFavoriteMoviesService
    {
        IEnumerable<T> GetAllByUserId<T>(string userId);
    }
}
