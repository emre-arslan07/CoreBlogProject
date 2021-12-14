using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryListDashboard()
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }
    }
}
