using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        public IActionResult Index()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }
    }
}
