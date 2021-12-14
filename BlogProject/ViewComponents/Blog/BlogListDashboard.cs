using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        private IBlogService _blogService;

        public BlogListDashboard()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetLast10Blog();
            return View(values);
        }
    }
}
