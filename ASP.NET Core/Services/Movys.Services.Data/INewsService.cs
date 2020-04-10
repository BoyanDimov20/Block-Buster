namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INewsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
