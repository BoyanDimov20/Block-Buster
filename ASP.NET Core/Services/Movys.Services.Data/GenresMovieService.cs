namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class GenresMovieService : IGenresMovieService
    {
        private readonly IRepository<GenresMovie> genresMovieRepository;

        public GenresMovieService(IRepository<GenresMovie> genresMovieRepository)
        {
            this.genresMovieRepository = genresMovieRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.genresMovieRepository.All().To<T>().ToList();
        }
    }
}
