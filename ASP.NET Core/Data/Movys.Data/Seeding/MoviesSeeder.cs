namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class MoviesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Movies.Any())
            {
                Movie movie = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Iron Man",
                    Description = "Tony Stark. Genius, billionaire, playboy, philanthropist. Son of legendary inventor and weapons contractor Howard Stark. When Tony Stark is assigned to give a weapons presentation to an Iraqi unit led by Lt. Col. James Rhodes, he's given a ride on enemy lines. That ride ends badly when Stark's Humvee that he's riding in is attacked by enemy combatants. He survives - barely - with a chest full of shrapnel and a car battery attached to his heart. In order to survive he comes up with a way to miniaturize the battery and figures out that the battery can power something else. Thus Iron Man is born. He uses the primitive device to escape from the cave in Iraq. Once back home, he then begins work on perfecting the Iron Man suit. But the man who was put in charge of Stark Industries has plans of his own to take over Tony's technology for other matters.",
                    TrailerUrl = "https://www.youtube.com/watch?v=8ugaeA-nMTc",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71lVAGaqBtL._AC_SY550_.jpg",
                    ReleaseYear = "2008",
                };

                Movie movie1 = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Daddy's home",
                    Description = "Stepfather Brad Whitaker is hoping for his stepchildren to love him and treat him like a dad. All is going well until the biological father, Dusty Mayron, shows up, then everything takes a toll. His stepchildren start putting him second and their father first, and now Dusty will have to learn that being a good dad is about pains and struggles. Brad will also experience once again what it's like to be a stepdad.",
                    TrailerUrl = "https://www.youtube.com/watch?v=arhMMJx7tCU",
                    ImageUrl = "https://cineboom.eu/wp-content/uploads/2015/03/daddys_home_ver3.jpg",
                    ReleaseYear = "2015",
                };

                await dbContext.Movies.AddAsync(movie);
                await dbContext.Movies.AddAsync(movie1);
            }
        }
    }
}
