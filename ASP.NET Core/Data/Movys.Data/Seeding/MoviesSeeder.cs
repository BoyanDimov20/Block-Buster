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

                Movie movie2 = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Avengers: Endgame",
                    Description = "Twenty-three days after Thanos had used the Infinity Gauntlet to disintegrate half of all life in the universe,[N 1] Carol Danvers rescues Tony Stark and Nebula from deep space and returns them to Earth, where they reunite with the remaining Avengers—Bruce Banner, Steve Rogers, Thor, Natasha Romanoff, and James Rhodes—and Rocket. Locating Thanos on an uninhabited planet, they plan to use the Infinity Stones to reverse \"the Snap\", but Thanos reveals he destroyed the Stones to prevent further use. Enraged, Thor decapitates Thanos.",
                    TrailerUrl = "https://www.youtube.com/watch?v=TcMBFSGVi1c",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                    ReleaseYear = "2019",
                };

                Movie movie3 = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Dark Knight",
                    Description = "A gang of criminals rob a Gotham City mob bank, murdering each other for a higher share of the money until only the Joker remains, who escapes with the money. Batman, District Attorney Harvey Dent and Lieutenant James Gordon form an alliance to rid Gotham City of organized crime. Bruce Wayne believes that with Dent as Gotham's protector, he can retire from being Batman and lead a normal life with Rachel Dawes – even though she and Dent are dating.",
                    TrailerUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/Dark_Knight.jpg",
                    ReleaseYear = "2008",
                };

                Movie movie4 = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Joker",
                    Description = "In 1981, party clown and aspiring stand-up comedian Arthur Fleck lives with his mother, Penny, in Gotham City. Gotham is rife with crime and unemployment, leaving swathes of the population disenfranchised and impoverished. Arthur suffers from a medical disorder that causes him to laugh at inappropriate times; he depends on social services for medication. After a gang of delinquents attacks Arthur in an alley, his co-worker, Randall, gives him a gun for protection. Arthur meets his neighbor, single mother Sophie Dumond, and invites her to his upcoming stand-up routine at a nightclub.",
                    TrailerUrl = "https://www.youtube.com/watch?v=-_DJEzZk2pc",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e1/Joker_%282019_film%29_poster.jpg",
                    ReleaseYear = "2019",
                };

                Movie movie5 = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Mission: Impossible – Fallout",
                    Description = "Two years after Solomon Lane's capture,[N 1] the remnants of his organization, the Syndicate, have reorganized as a terrorist group called the Apostles. IMF agent Ethan Hunt is assigned to buy three stolen plutonium cores in Berlin from Eastern European gangsters before the Apostles can. He is joined by Benji Dunn and Luther Stickell for the mission, but the team fails when Stickell is taken hostage and Hunt's attempt to save him allows the Apostles to make off with the plutonium. The team later captures nuclear weapons expert Nils Delbruuk, whose security clearance was revoked because of his anti-religious bigotry and who designed nuclear bombs for the Apostles' client, an extremist named John Lark. With the use of a fake broadcast, they manage to trick him into handing over a phone that he used to communicate with Lark.",
                    TrailerUrl = "https://www.youtube.com/watch?v=wb49-oV0F78",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/ff/MI_%E2%80%93_Fallout.jpg",
                    ReleaseYear = "2018",
                };

                await dbContext.Movies.AddAsync(movie);
                await dbContext.Movies.AddAsync(movie1);
                await dbContext.Movies.AddAsync(movie2);
                await dbContext.Movies.AddAsync(movie3);
                await dbContext.Movies.AddAsync(movie4);
                await dbContext.Movies.AddAsync(movie5);
            }
        }
    }
}
