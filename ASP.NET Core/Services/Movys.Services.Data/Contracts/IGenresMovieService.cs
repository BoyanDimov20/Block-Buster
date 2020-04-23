namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IGenresMovieService
    {
        IEnumerable<T> GetAll<T>(); 
    }
}
