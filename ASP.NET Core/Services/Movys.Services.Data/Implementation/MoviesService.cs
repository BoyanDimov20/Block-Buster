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

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository)
        {
            this.moviesRepository = moviesRepository;
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
