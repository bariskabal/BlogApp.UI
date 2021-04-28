using System.Threading.Tasks;
using BlogApp.UI.ApiServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UI.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryList(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryApiService.GetAllWithBlogsCountAsync().Result);
        }
    }
}