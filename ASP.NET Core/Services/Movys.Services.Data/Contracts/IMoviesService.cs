namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMoviesService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(string id);
    }
}
