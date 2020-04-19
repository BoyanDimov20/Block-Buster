namespace Movys.Web.ViewModels.News
{
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class TagsViewModel : IMapFrom<NewsTags>
    {
        public string TagId { get; set; }

        public string TagName { get; set; }
    }
}
