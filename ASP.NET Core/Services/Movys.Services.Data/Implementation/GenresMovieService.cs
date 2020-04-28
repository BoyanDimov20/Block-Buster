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

    public class GenresMovieService : IGenresMovieService
    {
        private readonly IRepository<GenresMovie> genresMovieRepository;

        public GenresMovieService(IRepository<GenresMovie> genresMovieRepository)
        {
            this.genresMovieRepository = genresMovieRepository;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.genresMovieRepository.All().To<T>().ToListAsync();
        }
    }
}
