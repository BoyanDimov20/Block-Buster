namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IRepository<GenresMovie> genresMovieRepository;

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository, IRepository<GenresMovie> genresMovieRepository)
        {
            this.moviesRepository = moviesRepository;
            this.genresMovieRepository = genresMovieRepository;
        }

        public async Task<string> CreateMovie(string title, DateTime releaseDate, string imageUrl, IEnumerable<string> genresIds, string description, string country = null, int? runtime = null, string trailerUrl = null)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                ReleaseDate = releaseDate,
                ReleaseYear = releaseDate.Year.ToString(),
                ImageUrl = imageUrl,
                Description = description,
                Country = country,
                Runtime = runtime,
                TrailerUrl = trailerUrl,
            };
            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();

            foreach (var genreId in genresIds)
            {
                var genreMovie = new GenresMovie
                {
                    MovieId = movie.Id,
                    GenreId = genreId,
                };
                await this.genresMovieRepository.AddAsync(genreMovie);
            }

            await this.genresMovieRepository.SaveChangesAsync();
            return movie.Id;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.moviesRepository.All().To<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(string id)
        {
            return await this.moviesRepository.All().Where(x => x.Id == id).To<T>().FirstAsync();
        }
    }
}
