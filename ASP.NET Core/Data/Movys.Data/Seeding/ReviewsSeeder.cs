namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class ReviewsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Reviews.Any())
            {
                var movieIds = dbContext.Movies.Select(x => x.Id).ToList();
                Random rng = new Random();
                var userId = dbContext.Users.Select(x => x.Id).First();

                foreach (var movieId in movieIds)
                {
                    Review review1 = new Review
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Very coool movie",
                        Content = "asdasdasbdasbda",
                        MovieId = movieId,
                        Rating = rng.Next(0, 11),
                        UserId = userId,
                    };

                    Review review2 = new Review
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Wtf is this shit",
                        Content = "0 HUMOR!!!!!!!!!!!!",
                        MovieId = movieId,
                        Rating = rng.Next(0, 11),
                        UserId = userId,
                    };

                    await dbContext.Reviews.AddAsync(review1);
                    await dbContext.Reviews.AddAsync(review2);
                }
            }
        }
    }
}
