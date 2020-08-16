namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        Task<IEnumerable<T>> GetAll<T>();

        Task<T> GetById<T>(string id);

        Task<string> CreateMovie(string title, DateTime releaseDate, string imageUrl, IEnumerable<string> genresIds, string description, string country = null, int? runtime = null, string trailerUrl = null);
    }
}
