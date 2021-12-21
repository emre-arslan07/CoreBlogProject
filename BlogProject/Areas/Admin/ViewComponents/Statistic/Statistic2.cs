using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        private IBlogService _blogService;

        public Statistic2()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.LastBlog = _blogService.GetLastBlog().BlogTitle;
            return View();
        }
    }
}
