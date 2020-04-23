namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.moviesRepository.All().To<T>().ToList();
        }

        public T GetById<T>(string id)
        {
            return this.moviesRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }
    }
}
