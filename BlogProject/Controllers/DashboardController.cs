using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;

        public DashboardController()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        public IActionResult Index()
        {
            ViewBag.AllBlogCount = _blogService.GetCountAllBlogs();
            ViewBag.WriterBlogCount = _blogService.GetCountByWriterID(1).ToString();
            ViewBag.CategoryCount = _categoryService.GetAllCategoryCount();
            return View();
        }
    }
}
