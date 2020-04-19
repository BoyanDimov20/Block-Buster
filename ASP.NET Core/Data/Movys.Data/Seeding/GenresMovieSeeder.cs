namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class GenresMovieSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.GenresMovies.Any())
            {
                var movies = dbContext.Movies.Select(x => x.Id).ToList();
                var genres = dbContext.Movies.Select(x => x.Id).ToList();
                Random rng = new Random();

                foreach (var movieId in movies)
                {
                    int num = rng.Next(0, genres.Count);

                    var genreMovie = new GenresMovie
                    {
                        GenreId = genres[num],
                        MovieId = movieId,
                    };

                    await dbContext.AddAsync(genreMovie);
                }

            }
        }
    }
}
