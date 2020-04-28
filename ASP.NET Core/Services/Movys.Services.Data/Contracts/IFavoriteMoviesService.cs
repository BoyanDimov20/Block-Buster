namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFavoriteMoviesService
    {
        Task<IEnumerable<T>> GetAllByUserId<T>(string userId);
    }
}
