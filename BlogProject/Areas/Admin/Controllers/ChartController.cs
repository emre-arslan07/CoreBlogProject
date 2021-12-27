using BlogProject.Areas.Admin.Models;
using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        private IBlogService _blogService;

        public ChartController()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            
            return Json(new { jsonlist = CategoryBlogChart() });
        }

        public List<CategoryClass> CategoryBlogChart()
        {
            var result = _blogService.GetAllBlogByCategory().ToList().GroupBy(x => new { x.Category.CategoryName })
                .Select(g => new CategoryClass
                {
                    categoryname = g.Key.CategoryName,
                    categorycount = g.Select(x => x.BlogID).Count()
                }).ToList();
            return result;
        }
    }
}
