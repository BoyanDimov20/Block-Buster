namespace Movys.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Movys.Data;
    using Movys.Data.Models;
    using Movys.Data.Repositories;
    using Xunit;

    public class ReviewsServiceTests
    {
        [Fact]
        public async Task CreateReviewCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Review>(new ApplicationDbContext(options.Options));

            var service = new ReviewsService(repository);
            var title = "Hello";
            var content = "Ivan";
            var userId = "45645645";
            var movieId = "1235876";

            await service.AddReview(title, content, 5.5, movieId, userId);
            var review = repository.All().First(x => x.UserId == userId && x.MovieId == movieId);

            Assert.Equal(5.5, review.Rating);
            Assert.Equal(title, review.Title);
            Assert.Equal(content, review.Content);
        }
    }
}
