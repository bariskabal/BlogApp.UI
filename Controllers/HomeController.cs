using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.UI.ApiServices.Interface;
using BlogApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BlogApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogApiService _blogApiService;
        private readonly ICategoryApiService _categoryApiService;
        public HomeController(IBlogApiService blogApiService,ICategoryApiService categoryApiService)
        {
            _blogApiService = blogApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index(int? categoryId,string s)
        {
            if (categoryId.HasValue)
            {
                ViewBag.ActiveCategory = categoryId;

                return View(await _blogApiService.GetAllByCategoryIdAsync((int)categoryId));
            }
            if (!string.IsNullOrWhiteSpace(s))
            {
                ViewBag.SearchString =s;
                return View(await _blogApiService.SearchAsync(s));
            }
            return View(await _blogApiService.GetAllAsync());
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.Comments = await _blogApiService.GetCommentsAsync(id,null);
            return View(await _blogApiService.GetByIdAsync(id));
        }
        public async Task<IActionResult> AddToComment(CommentAddModel model)
        {
            await _blogApiService.AddToComment(model);
            return RedirectToAction("BlogDetail",new{id=model.BlogId});
        }

       
    }
}
