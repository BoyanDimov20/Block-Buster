namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class MoviesCastMemberSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.MoviesCastMembers.Any())
            {
                var castMembers = dbContext.CastMembers.Select(x => x.Id).ToList();
                var movies = dbContext.Movies.Select(x => x.Id).ToList();
                Random rng = new Random();

                foreach (var movieId in movies)
                {
                    foreach (var castMemberId in castMembers)
                    {
                        RoleType role = (RoleType)rng.Next(0, 5);
                        var moviesCastMember = new MoviesCastMember
                        {
                            CastMemberId = castMemberId,
                            MovieId = movieId,
                            RoleType = role,
                            RoleName = role.ToString(),
                        };

                        await dbContext.AddAsync(moviesCastMember);
                    }
                }

            }
        }
    }
}
