namespace Movys.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels;
    using Movys.Web.ViewModels.Home;
    using Movys.Web.ViewModels.Movies;
    using Movys.Web.ViewModels.News;

    public class HomeController : BaseController
    {
        private readonly IMoviesService moviesService;
        private readonly ICelebsService celebsService;
        private readonly INewsService newsService;
        private readonly IRepository<Newsletter> newsLettersRepository;

        public HomeController(IMoviesService moviesService, ICelebsService celebsService, INewsService newsService, IRepository<Newsletter> newsLettersRepository)
        {
            this.moviesService = moviesService;
            this.celebsService = celebsService;
            this.newsService = newsService;
            this.newsLettersRepository = newsLettersRepository;
        }

        public IActionResult Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel
            {
                MostPopularMovies = this.moviesService.GetAll<MovieViewModel>().OrderByDescending(x => x.Reviews.Count()).Take(10),
                TopRatedMovies = this.moviesService.GetAll<MovieViewModel>().OrderByDescending(x => x.Rating).Take(10),
                ComingSoonMovies = this.moviesService.GetAll<MovieViewModel>().Take(10),
                MostReviewedMovies = this.moviesService.GetAll<MovieViewModel>().OrderByDescending(x => x.Reviews.Count()).Take(10),
                Celebrities = this.celebsService.GetAll<ViewModels.Home.CastMemberViewModel>().Take(4),
                News = this.newsService.GetAll<NewsViewModel>().OrderByDescending(x => x.CreatedOn).Take(5),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeEmail([FromBody] SubscriptionViewModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.newsLettersRepository.All().Any(x => x.Email.ToLower() == inputModel.Email.ToLower()))
                {
                    Newsletter newsletter = new Newsletter
                    {
                        Email = inputModel.Email,
                    };
                    await this.newsLettersRepository.AddAsync(newsletter);
                    await this.newsLettersRepository.SaveChangesAsync();
                    return this.Ok("You Subcribed Succesfully!");
                }

                return this.Ok("Already Subscribed!");
            }

            return this.ValidationProblem();
        }
    }
}
