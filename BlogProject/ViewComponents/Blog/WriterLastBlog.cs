using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        private IBlogService _blogService;
        private IWriterService _writerService;

        public WriterLastBlog()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        public IViewComponentResult Invoke(int id)
        {
            int writerId = _blogService.GetWriterIdByBlogId(id);
            var values = _blogService.GetBlogListByWriter(writerId);
            return View(values);
        }
    }
}
