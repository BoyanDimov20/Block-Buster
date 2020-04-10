namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> entityRepository;

        public NewsService(IDeletableEntityRepository<News> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.entityRepository.All().To<T>().ToList();
        }
    }
}
