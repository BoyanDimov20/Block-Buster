namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        IEnumerable<T> GetAllByNewsId<T>(string id);

        Task CreateCommentAsync(string content, string userId, string newsId);

        int GetCount();
    }
}
