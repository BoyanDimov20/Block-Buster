namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class GenresSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Genres.Any())
            {
                var genres = new Genre[]
                {
                    new Genre()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Action",
                    },

                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Comedy",
                    },

                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Adventure",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Crime",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Drama",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Fantasy",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Historical",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Horror",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Romance",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Saga",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Satire",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Science fiction",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Thriller",
                    },
                    new Genre
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Animation",
                    },
                };
                foreach (var genre in genres)
                {
                    await dbContext.Genres.AddAsync(genre);
                }

            }
        }
    }
}
