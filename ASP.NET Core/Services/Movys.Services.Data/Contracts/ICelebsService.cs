namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICelebsService
    {
        Task<IEnumerable<T>> GetAll<T>();

        int GetCount();
    }
}
