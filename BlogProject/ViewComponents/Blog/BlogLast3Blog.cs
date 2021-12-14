using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Blog
{
    public class BlogLast3Blog : ViewComponent
    {
        private IBlogService _blogService;

        public BlogLast3Blog()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetLast3Blog();
            return View(values);
        }
    }
}
