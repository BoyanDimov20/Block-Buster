namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> repository;

        public ReviewsService(IDeletableEntityRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task AddReview(string title, string content, double rating, string movieId, string userId)
        {
            Review review = new Review
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Content = content,
                Rating = rating,
                MovieId = movieId,
                UserId = userId,
            };

            await this.repository.AddAsync(review);
            await this.repository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.repository.All().To<T>().ToList();
        }
    }
}
