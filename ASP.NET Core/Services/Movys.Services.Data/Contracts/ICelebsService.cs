namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICelebsService
    {
        IEnumerable<T> GetAll<T>();

        int GetCount();
    }
}
