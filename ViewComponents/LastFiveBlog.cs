using BlogApp.UI.ApiServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UI.ViewComponents
{
    public class LastFiveBlog : ViewComponent
    {
        private readonly IBlogApiService _blogApiService;
        public LastFiveBlog(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_blogApiService.GetLastFiveAsync().Result);
        }
    }
}