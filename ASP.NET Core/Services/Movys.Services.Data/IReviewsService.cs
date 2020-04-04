namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IReviewsService
    {
        Task AddReview(string title, string content, double rating, string movieId, string userId);

        IEnumerable<T> GetAll<T>();
    }
}
